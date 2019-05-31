﻿using LinqToDB.Common;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToDB.SqlQuery
{
	public class SqlMergeSourceTable : SqlTable
	{
		public SqlMergeStatement Merge { get; }

		public SqlMergeSourceTable(
			[JetBrains.Annotations.NotNull] MappingSchema mappingSchema,
			[JetBrains.Annotations.NotNull] SqlMergeStatement merge,
			Type sourceType)
			 : base(mappingSchema, sourceType, "Source")
		{
			Name = "Source";
			Merge = merge;
		}

		//public string SourceName { get; set; } = "Source";

		private IDictionary<SqlField, Tuple<SqlField, int>>         SourceFieldsByBase     { get; } = new Dictionary<SqlField, Tuple<SqlField, int>>();
		private IDictionary<ISqlExpression, Tuple<SqlField, int>> SourceFieldsByExpression { get; } = new Dictionary<ISqlExpression, Tuple<SqlField, int>>();

		public SqlValuesTable SourceEnumerable { get; internal set; }
		public SelectQuery SourceQuery { get; internal set; }

		public ISqlTableSource Source => (ISqlTableSource)SourceQuery ?? SourceEnumerable;

		public List<SqlField> SourceFields { get; } = new List<SqlField>();

		public override QueryElementType ElementType => QueryElementType.MergeSourceTable;
		public override SqlTableType SqlTableType => SqlTableType.MergeSource;

		public override ISqlExpression Walk(WalkOptions options, Func<ISqlExpression, ISqlExpression> func)
		{
			return SourceQuery?.Walk(options, func);
		}

		public void WalkQueries(Func<SelectQuery, SelectQuery> func)
		{
			if (SourceQuery != null)
				SourceQuery = func(SourceQuery);
		}

		public StringBuilder ToString(StringBuilder sb, Dictionary<IQueryElement, IQueryElement> dic)
		{
			if (SourceQuery != null)
				((IQueryElement)SourceQuery).ToString(sb, dic);
			else
				sb.Append("<TODO:List>");

			return sb;
		}

		public bool IsParameterDependent
		{
			get
			{
				return SourceQuery?.IsParameterDependent ?? false;
			}

			set
			{
				if (SourceQuery != null)
					SourceQuery.IsParameterDependent = value;
			}
		}

		internal SqlField RegisterSourceField(ISqlExpression baseExpression, ISqlExpression expression, int index, Func<SqlField> fieldFactory)
		{
			var baseField = baseExpression as SqlField;
			if (baseField != null && SourceFieldsByBase.TryGetValue(baseField, out var value))
				return value.Item1;

			if (baseField == null && expression != null && SourceFieldsByExpression.TryGetValue(expression, out value))
				return value.Item1;

			var newField = fieldFactory();

			Utils.MakeUniqueNames(new[] { newField }, SourceFieldsByExpression.Values.Select(t => t.Item1.Name), f => f.Name, (f, n) =>
			{
				f.Name = n;
				f.PhysicalName = n;
			}, f => "source_field");

			SourceFields.Insert(index, newField);

			if (expression != null && !SourceFieldsByExpression.ContainsKey(expression))
				SourceFieldsByExpression.Add(expression, Tuple.Create(newField, index));
			if (baseField != null)
				SourceFieldsByBase.Add(baseField, Tuple.Create(newField, index));
			return newField;

		}

		#region IQueryElement Members

		public string SqlText =>
			((IQueryElement)this).ToString(new StringBuilder(), new Dictionary<IQueryElement, IQueryElement>())
			.ToString();


		#endregion
	}
}
