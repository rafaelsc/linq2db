﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LinqToDB.Reflection
{
	using Expressions;
	using Linq;

	/// <summary>
	/// This API supports the LinqToDB infrastructure and is not intended to be used  directly from your code.
	/// This API may change or be removed in future releases.
	/// </summary>
	public static class Methods
	{
		public static class Enumerable
		{
			public static readonly MethodInfo ToArray     = MemberHelper.MethodOfGeneric<IEnumerable<int>>(e => e.ToArray());
			public static readonly MethodInfo ToList      = MemberHelper.MethodOfGeneric<IEnumerable<int>>(e => e.ToList());

			public static readonly MethodInfo Select      = MemberHelper.MethodOfGeneric<IEnumerable<int>>(e => e.Select(p => p));
			public static readonly MethodInfo Where       = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.Where((Func<int, bool>)null!));
			public static readonly MethodInfo Take        = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.Take(1));
			public static readonly MethodInfo Skip        = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.Skip(1));

			public static readonly MethodInfo First                   = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.First());
			public static readonly MethodInfo FirstOrDefault          = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.FirstOrDefault());
			public static readonly MethodInfo FirstOrDefaultCondition = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.FirstOrDefault(e => true));

			public static readonly MethodInfo DefaultIfEmpty       = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.DefaultIfEmpty());
			public static readonly MethodInfo DefaultIfEmptyValue  = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.DefaultIfEmpty(0));

			public static readonly MethodInfo OfType               = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.OfType<double>());

			public static readonly MethodInfo SelectManySimple     = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.SelectMany(a => new int[0]));
			public static readonly MethodInfo SelectManyProjection = MemberHelper.MethodOfGeneric<IEnumerable<int>>(q => q.SelectMany(a => new int[0], (m, d) => d));

			public static readonly MethodInfo Join      = MemberHelper.MethodOfGeneric<IEnumerable<LW1>, IEnumerable<LW2>>((m, d) => m.Join(d, _ => _.Value1, _ => _.Value2, (m, d) => d));
			public static readonly MethodInfo GroupJoin = MemberHelper.MethodOfGeneric<IEnumerable<LW1>, IEnumerable<LW2>>((m, d) => m.GroupJoin(d, _ => _.Value1, _ => _.Value2, (m, d) => d));
		}

		public static class Queryable
		{
			public static readonly MethodInfo ToArray      = MemberHelper.MethodOfGeneric<IQueryable<int>>(e => e.ToArray());
			public static readonly MethodInfo ToList       = MemberHelper.MethodOfGeneric<IQueryable<int>>(e => e.ToList());
			public static readonly MethodInfo AsQueryable  = MemberHelper.MethodOfGeneric<IEnumerable<int>>(e => e.AsQueryable());
			public static readonly MethodInfo AsEnumerable = MemberHelper.MethodOfGeneric<IQueryable<int>>(e => e.AsEnumerable());

			public static readonly MethodInfo Select     = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.Select(p => p));
			public static readonly MethodInfo Where      = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.Where((Expression<Func<int, bool>>)null!));
			public static readonly MethodInfo Take       = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.Take(1));
			public static readonly MethodInfo Skip       = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.Skip(1));

			public static readonly MethodInfo First                   = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.First());
			public static readonly MethodInfo FirstOrDefault          = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.FirstOrDefault());
			public static readonly MethodInfo FirstOrDefaultCondition = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.FirstOrDefault(e => true));

			public static readonly MethodInfo DefaultIfEmpty       = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.DefaultIfEmpty());
			public static readonly MethodInfo DefaultIfEmptyValue  = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.DefaultIfEmpty(0));

			public static readonly MethodInfo OfType               = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.OfType<double>());

			public static readonly MethodInfo SelectManySimple     = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.SelectMany(a => new int[0]));
			public static readonly MethodInfo SelectManyProjection = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.SelectMany(a => new int[0], (m, d) => d));

			public static readonly MethodInfo Join      = MemberHelper.MethodOfGeneric<IQueryable<LW1>, IQueryable<LW2>>((m, d) => m.Join(d, _ => _.Value1, _ => _.Value2, (m, d) => d));
			public static readonly MethodInfo GroupJoin = MemberHelper.MethodOfGeneric<IQueryable<LW1>, IQueryable<LW2>>((m, d) => m.GroupJoin(d, _ => _.Value1, _ => _.Value2, (m, d) => d));
		}

		public static class LinqToDB
		{
			public static readonly MethodInfo GetTable    = MemberHelper.MethodOfGeneric<IDataContext>(dc => dc.GetTable<object>());

			public static readonly MethodInfo LoadWith              = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Single2));
			public static readonly MethodInfo LoadWithSingleFilter  = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Single2, eq => eq.Where(e => e.Value2 == 1)));
			public static readonly MethodInfo LoadWithManyFilter    = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Many2,   eq => eq.Where(e => e.Value2 == 1)));
			
			public static readonly MethodInfo ThenLoadFromSingle             = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Single2).ThenLoad(e => e.Single3));
			public static readonly MethodInfo ThenLoadFromMany               = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Many2).ThenLoad(e => e.Single3));
			
			public static readonly MethodInfo ThenLoadFromSingleSingleFilter = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Single2).ThenLoad(e => e.Single3, eq => eq.Where(e => e.Value3 == 3)));
			public static readonly MethodInfo ThenLoadFromSingleManyFilter   = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Single2).ThenLoad(e => e.Many3,   eq => eq.Where(e => e.Value3 == 3)));
			public static readonly MethodInfo ThenLoadFromManySingleFilter   = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Many2).ThenLoad(e => e.Single3,   eq => eq.Where(e => e.Value3 == 3)));
			public static readonly MethodInfo ThenLoadFromManyManyFilter     = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.LoadWith(e => e.Many2).ThenLoad(e => e.Many3,     eq => eq.Where(e => e.Value3 == 3)));


			public static readonly MethodInfo RemoveOrderBy       = MemberHelper.MethodOfGeneric<IQueryable<object>>(q => q.RemoveOrderBy());
			public static readonly MethodInfo IgnoreFilters       = MemberHelper.MethodOfGeneric<IQueryable<object>>(q => q.IgnoreFilters());

			public static class Table
			{
				public static readonly MethodInfo TableName    = MemberHelper.MethodOfGeneric<ITable<int>>(t => t.TableName(null!));
				public static readonly MethodInfo SchemaName   = MemberHelper.MethodOfGeneric<ITable<int>>(t => t.SchemaName(null!));
				public static readonly MethodInfo DatabaseName = MemberHelper.MethodOfGeneric<ITable<int>>(t => t.DatabaseName(null!));
				public static readonly MethodInfo ServerName   = MemberHelper.MethodOfGeneric<ITable<int>>(t => t.ServerName(null!));

				public static readonly MethodInfo With                = MemberHelper.MethodOfGeneric<ITable<int>>(t => t.With(""));
				public static readonly MethodInfo WithTableExpression = MemberHelper.MethodOfGeneric<ITable<int>>(t => t.WithTableExpression(""));
			}

			public static class GroupBy
			{
				public static readonly MethodInfo Rollup       = MemberHelper.MethodOfGeneric<Sql.IGroupBy>(g => g.Rollup<object>(null!));
				public static readonly MethodInfo Cube         = MemberHelper.MethodOfGeneric<Sql.IGroupBy>(g => g.Cube<object>(null!));
				public static readonly MethodInfo GroupingSets = MemberHelper.MethodOfGeneric<Sql.IGroupBy>(g => g.GroupingSets<object>(null!));

				public static readonly MethodInfo Grouping     = MemberHelper.MethodOf(() => Sql.Grouping(null!));

			}

			public static class Update
			{
				public static readonly MethodInfo UpdateUpdatable             = MemberHelper.MethodOfGeneric<IUpdatable<LW1>>(u => u.Update());
				public static readonly MethodInfo UpdateUpdatableAsync        = MemberHelper.MethodOfGeneric<IUpdatable<LW1>>(u => u.UpdateAsync(default));

				public static readonly MethodInfo UpdateSetter                = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, LW1>> s) => q.Update(s));
				public static readonly MethodInfo UpdateSetterAsync           = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, LW1>> s) => q.UpdateAsync(s, default));
				public static readonly MethodInfo UpdatePredicateSetter       = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, bool>> p, Expression<Func<LW1, LW1>> s) => q.Update(p, s));
				public static readonly MethodInfo UpdatePredicateSetterAsync  = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, bool>> p, Expression<Func<LW1, LW1>> s) => q.UpdateAsync(p, s, default));
				public static readonly MethodInfo UpdateTarget                = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.Update(t, s));
				public static readonly MethodInfo UpdateTargetAsync           = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.UpdateAsync(t, s, default));
				public static readonly MethodInfo UpdateTargetFuncSetter      = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, LW2>> t, Expression<Func<LW1, LW2>> s) => q.Update(t, s));
				public static readonly MethodInfo UpdateTargetFuncSetterAsync = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, LW2>> t, Expression<Func<LW1, LW2>> s) => q.UpdateAsync(t, s, default));

				public static readonly MethodInfo AsUpdatable            = MemberHelper.MethodOfGeneric<IQueryable<int>>(q => q.AsUpdatable());
				public static readonly MethodInfo SetQueryableExpression = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.Set(e => e.Value1, () => 1));
				public static readonly MethodInfo SetQueryablePrev       = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.Set(e => e.Value1, prev => 1));
				public static readonly MethodInfo SetQueryableValue      = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.Set(e => e.Value1, 1));
				public static readonly MethodInfo SetUpdatableExpression = MemberHelper.MethodOfGeneric<IUpdatable<LW1>>(q => q.Set(e => e.Value1, () => 1));
				public static readonly MethodInfo SetUpdatablePrev       = MemberHelper.MethodOfGeneric<IUpdatable<LW1>>(q => q.Set(e => e.Value1, prev => 1));
				public static readonly MethodInfo SetUpdatableValue      = MemberHelper.MethodOfGeneric<IUpdatable<LW1>>(q => q.Set(e => e.Value1, 1));
			}

			public static class Insert
			{
				public static class Q
				{
					public static readonly MethodInfo Into        = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t) => q.Into(t));
					
					public static readonly MethodInfo Insert      = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.Insert(t, s));
					public static readonly MethodInfo InsertAsync = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertAsync(t, s, default));

					public static readonly MethodInfo InsertWithIdentity             = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithIdentity(t, s));
					public static readonly MethodInfo InsertWithIdentityAsync        = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithIdentityAsync(t, s, default));
					public static readonly MethodInfo InsertWithInt32Identity        = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithInt32Identity(t, s));
					public static readonly MethodInfo InsertWithInt32IdentityAsync   = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithInt32IdentityAsync(t, s, default));
					public static readonly MethodInfo InsertWithInt64Identity        = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithInt64Identity(t, s));
					public static readonly MethodInfo InsertWithInt64IdentityAsync   = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithInt64IdentityAsync(t, s, default));
					public static readonly MethodInfo InsertWithDecimalIdentity      = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithDecimalIdentity(t, s));
					public static readonly MethodInfo InsertWithDecimalIdentityAsync = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, ITable<LW2> t, Expression<Func<LW1, LW2>> s) => q.InsertWithDecimalIdentityAsync(t, s, default));
				}

				public static class DC
				{
					public static readonly MethodInfo Into        = MemberHelper.MethodOfGeneric((IDataContext dc, ITable<LW1> t) => dc.Into(t));
					
					public static readonly MethodInfo Insert      = MemberHelper.MethodOfGeneric((IDataContext dc, LW1 o) => dc.Insert(o, "tn", "db", "sch", "srv"));
					public static readonly MethodInfo InsertAsync = MemberHelper.MethodOfGeneric((IDataContext dc, LW1 o) => dc.InsertAsync(o, "tn", "db", "sch", "srv", default));
				}
				
				public static class T
				{
					public static readonly MethodInfo Value             = MemberHelper.MethodOfGeneric<ITable<LW1>>(q => q.Value(e => e.Value1, 1));
					public static readonly MethodInfo ValueExpression   = MemberHelper.MethodOfGeneric<ITable<LW1>>(q => q.Value(e => e.Value1, () => 1));
				
					public static readonly MethodInfo Insert      = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.Insert(s));
					public static readonly MethodInfo InsertAsync = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertAsync(s, default));
					
					public static readonly MethodInfo InsertWithIdentity             = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithIdentity(s));
					public static readonly MethodInfo InsertWithIdentityAsync        = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithIdentityAsync(s, default));
					public static readonly MethodInfo InsertWithInt32Identity        = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithInt32Identity(s));
					public static readonly MethodInfo InsertWithInt32IdentityAsync   = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithInt32IdentityAsync(s, default));
					public static readonly MethodInfo InsertWithInt64Identity        = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithInt64Identity(s));
					public static readonly MethodInfo InsertWithInt64IdentityAsync   = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithInt64IdentityAsync(s, default));
					public static readonly MethodInfo InsertWithDecimalIdentity      = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithDecimalIdentity(s));
					public static readonly MethodInfo InsertWithDecimalIdentityAsync = MemberHelper.MethodOfGeneric((ITable<LW1> t, Expression<Func<LW1>> s) => t.InsertWithDecimalIdentityAsync(s, default));
				}
				
				public static class VI
				{
					public static readonly MethodInfo Value           = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(q => q.Value(e => e.Value1, 1));
					public static readonly MethodInfo ValueExpression = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(q => q.Value(e => e.Value1, () => 1));
				
					public static readonly MethodInfo Insert          = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.Insert());
					public static readonly MethodInfo InsertAsync     = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertAsync(default));
				
					public static readonly MethodInfo InsertWithIdentity             = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithIdentity());
					public static readonly MethodInfo InsertWithIdentityAsync        = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithIdentityAsync(default));
					public static readonly MethodInfo InsertWithInt32Identity        = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithInt32Identity());
					public static readonly MethodInfo InsertWithInt32IdentityAsync   = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithInt32IdentityAsync(default));
					public static readonly MethodInfo InsertWithInt64Identity        = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithInt64Identity());
					public static readonly MethodInfo InsertWithInt64IdentityAsync   = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithInt64IdentityAsync(default));
					public static readonly MethodInfo InsertWithDecimalIdentity      = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithDecimalIdentity());
					public static readonly MethodInfo InsertWithDecimalIdentityAsync = MemberHelper.MethodOfGeneric<IValueInsertable<LW1>>(i => i.InsertWithDecimalIdentityAsync(default));
				}

				public static class SI
				{
					public static readonly MethodInfo Value                 = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(q => q.Value(e => e.Value2, 1));
					public static readonly MethodInfo ValueExpression       = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(q => q.Value(e => e.Value2, () => 1));
					public static readonly MethodInfo ValueSourceExpression = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(q => q.Value(t => t.Value2, s => s.Value1));

					public static readonly MethodInfo Insert      = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(q => q.Insert());
					public static readonly MethodInfo InsertAsync = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(q => q.InsertAsync(default));
					
					public static readonly MethodInfo InsertWithIdentity             = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithIdentity());
					public static readonly MethodInfo InsertWithIdentityAsync        = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithIdentityAsync(default));
					public static readonly MethodInfo InsertWithInt32Identity        = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithInt32Identity());
					public static readonly MethodInfo InsertWithInt32IdentityAsync   = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithInt32IdentityAsync(default));
					public static readonly MethodInfo InsertWithInt64Identity        = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithInt64Identity());
					public static readonly MethodInfo InsertWithInt64IdentityAsync   = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithInt64IdentityAsync(default));
					public static readonly MethodInfo InsertWithDecimalIdentity      = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithDecimalIdentity());
					public static readonly MethodInfo InsertWithDecimalIdentityAsync = MemberHelper.MethodOfGeneric<ISelectInsertable<LW1, LW2>>(i => i.InsertWithDecimalIdentityAsync(default));
				}
			}

			public static class Delete
			{
				public static readonly MethodInfo DeleteQueryable               = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(q => q.Delete());
				public static readonly MethodInfo DeleteQueryableAsync          = MemberHelper.MethodOfGeneric<IQueryable<LW1>>(dc => dc.DeleteAsync(default));
				public static readonly MethodInfo DeleteQueryablePredicate      = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, bool>> p) => q.Delete(p));
				public static readonly MethodInfo DeleteQueryablePredicateAsync = MemberHelper.MethodOfGeneric((IQueryable<LW1> q, Expression<Func<LW1, bool>> p) => q.DeleteAsync(p, default));
			}

			public static class Tools
			{
				public static readonly MethodInfo CreateEmptyQuery  = MemberHelper.MethodOfGeneric(() => Common.Tools.CreateEmptyQuery<int>());
			}
		}

		#region Method definition helper classes

		#pragma warning disable 649

		abstract class LW1
		{
			public int   Value1;

			public LW2   Single2 = null!;
			public LW2[] Many2   = null!;
		}

		abstract class LW2
		{
			public int   Value2;

			public LW3   Single3 = null!;
			public LW3[] Many3   = null!;
				
		}

		abstract class LW3
		{
			public int Value3;
		}

		#pragma warning restore 649

		#endregion

	}
}
