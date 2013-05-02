﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/t4models).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace FirebirdDataContext
{
	/// <summary>
	/// Database       : TestData
	/// Data Source    : DBHost
	/// Server Version : WI-V2.5.1.26351 Firebird 2.5
	/// </summary>
	public partial class TestDataDB : LinqToDB.Data.DataConnection
	{
		public ITable<ALLTYPE>      ALLTYPES       { get { return this.GetTable<ALLTYPE>(); } }
		public ITable<BINARYDATA>   BINARYDATAs    { get { return this.GetTable<BINARYDATA>(); } }
		public ITable<CHILD>        Children       { get { return this.GetTable<CHILD>(); } }
		public ITable<DATATYPETEST> DATATYPETESTs  { get { return this.GetTable<DATATYPETEST>(); } }
		public ITable<DOCTOR>       DOCTORs        { get { return this.GetTable<DOCTOR>(); } }
		public ITable<DUAL>         DUALs          { get { return this.GetTable<DUAL>(); } }
		public ITable<GRANDCHILD>   GRANDCHILDs    { get { return this.GetTable<GRANDCHILD>(); } }
		public ITable<LINQDATATYPE> LINQDATATYPES  { get { return this.GetTable<LINQDATATYPE>(); } }
		public ITable<PARENT>       PARENTs        { get { return this.GetTable<PARENT>(); } }
		public ITable<PATIENT>      PATIENTs       { get { return this.GetTable<PATIENT>(); } }
		public ITable<PERSON>       People         { get { return this.GetTable<PERSON>(); } }
		public ITable<PERSONVIEW>   PERSONVIEWs    { get { return this.GetTable<PERSONVIEW>(); } }
		public ITable<SEQUENCETEST> SEQUENCETESTs  { get { return this.GetTable<SEQUENCETEST>(); } }
		public ITable<TESTIDENTITY> TESTIDENTITies { get { return this.GetTable<TESTIDENTITY>(); } }

		public TestDataDB()
		{
		}

		public TestDataDB(string configuration)
			: base(configuration)
		{
		}
	}

	[Table("ALLTYPES")]
	public partial class ALLTYPE
	{
		[PrimaryKey, NotNull    ] public int       ID                { get; set; } // integer
		[Column,        Nullable] public long?     BIGINTDATATYPE    { get; set; } // bigint
		[Column,        Nullable] public short?    SMALLINTDATATYPE  { get; set; } // smallint
		[Column,        Nullable] public decimal?  DECIMALDATATYPE   { get; set; } // decimal(18,0)
		[Column,        Nullable] public int?      INTDATATYPE       { get; set; } // integer
		[Column,        Nullable] public float?    FLOATDATATYPE     { get; set; } // float
		[Column,        Nullable] public float?    REALDATATYPE      { get; set; } // float
		[Column,        Nullable] public DateTime? TIMESTAMPDATATYPE { get; set; } // timestamp
		[Column,        Nullable] public string    CHARDATATYPE      { get; set; } // char(1)
		[Column,        Nullable] public string    VARCHARDATATYPE   { get; set; } // varchar(20)
		[Column,        Nullable] public string    TEXTDATATYPE      { get; set; } // blob sub_type 1
		[Column,        Nullable] public string    NCHARDATATYPE     { get; set; } // char(20)
		[Column,        Nullable] public string    NVARCHARDATATYPE  { get; set; } // varchar(20)
		[Column,        Nullable] public byte[]    BLOBDATATYPE      { get; set; } // blob
	}

	[Table("BINARYDATA")]
	public partial class BINARYDATA
	{
		[PrimaryKey, NotNull] public int    BINARYDATAID { get; set; } // integer
		[Column,     NotNull] public int    STAMP        { get; set; } // integer
		[Column,     NotNull] public byte[] DATA         { get; set; } // blob
	}

	[Table("CHILD")]
	public partial class CHILD
	{
		[Column, Nullable] public int? PARENTID { get; set; } // integer
		[Column, Nullable] public int? CHILDID  { get; set; } // integer
	}

	[Table("DATATYPETEST")]
	public partial class DATATYPETEST
	{
		[PrimaryKey, NotNull    ] public int       DATATYPEID { get; set; } // integer
		[Column,        Nullable] public byte[]    BINARY_    { get; set; } // blob
		[Column,        Nullable] public string    BOOLEAN_   { get; set; } // char(1)
		[Column,        Nullable] public short?    BYTE_      { get; set; } // smallint
		[Column,        Nullable] public byte[]    BYTES_     { get; set; } // blob
		[Column,        Nullable] public string    CHAR_      { get; set; } // char(1)
		[Column,        Nullable] public DateTime? DATETIME_  { get; set; } // timestamp
		[Column,        Nullable] public decimal?  DECIMAL_   { get; set; } // decimal(10,2)
		[Column,        Nullable] public double?   DOUBLE_    { get; set; } // double precision
		[Column,        Nullable] public string    GUID_      { get; set; } // char(38)
		[Column,        Nullable] public short?    INT16_     { get; set; } // smallint
		[Column,        Nullable] public int?      INT32_     { get; set; } // integer
		[Column,        Nullable] public decimal?  INT64_     { get; set; } // numeric(11,0)
		[Column,        Nullable] public decimal?  MONEY_     { get; set; } // decimal(18,4)
		[Column,        Nullable] public short?    SBYTE_     { get; set; } // smallint
		[Column,        Nullable] public float?    SINGLE_    { get; set; } // float
		[Column,        Nullable] public byte[]    STREAM_    { get; set; } // blob
		[Column,        Nullable] public string    STRING_    { get; set; } // varchar(50)
		[Column,        Nullable] public short?    UINT16_    { get; set; } // smallint
		[Column,        Nullable] public int?      UINT32_    { get; set; } // integer
		[Column,        Nullable] public decimal?  UINT64_    { get; set; } // numeric(11,0)
		[Column,        Nullable] public string    XML_       { get; set; } // char(1000)
	}

	[Table("DOCTOR")]
	public partial class DOCTOR
	{
		[Column, NotNull] public int    PERSONID { get; set; } // integer
		[Column, NotNull] public string TAXONOMY { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK_DOCTOR_PERSON
		/// </summary>
		[Association(ThisKey="PERSONID", OtherKey="PERSONID", CanBeNull=false)]
		public PERSON PERSON { get; set; }

		#endregion
	}

	[Table("DUAL")]
	public partial class DUAL
	{
		[Column, Nullable] public string DUMMY { get; set; } // varchar(10)
	}

	[Table("GRANDCHILD")]
	public partial class GRANDCHILD
	{
		[Column, Nullable] public int? PARENTID     { get; set; } // integer
		[Column, Nullable] public int? CHILDID      { get; set; } // integer
		[Column, Nullable] public int? GRANDCHILDID { get; set; } // integer
	}

	[Table("LINQDATATYPES")]
	public partial class LINQDATATYPE
	{
		[Column, Nullable] public int?      ID             { get; set; } // integer
		[Column, Nullable] public decimal?  MONEYVALUE     { get; set; } // decimal(10,4)
		[Column, Nullable] public DateTime? DATETIMEVALUE  { get; set; } // timestamp
		[Column, Nullable] public DateTime? DATETIMEVALUE2 { get; set; } // timestamp
		[Column, Nullable] public string    BOOLVALUE      { get; set; } // char(1)
		[Column, Nullable] public string    GUIDVALUE      { get; set; } // char(38)
		[Column, Nullable] public byte[]    BINARYVALUE    { get; set; } // blob
		[Column, Nullable] public short?    SMALLINTVALUE  { get; set; } // smallint
		[Column, Nullable] public int?      INTVALUE       { get; set; } // integer
		[Column, Nullable] public long?     BIGINTVALUE    { get; set; } // bigint
	}

	[Table("PARENT")]
	public partial class PARENT
	{
		[Column, Nullable] public int? PARENTID { get; set; } // integer
		[Column, Nullable] public int? VALUE1   { get; set; } // integer
	}

	[Table("PATIENT")]
	public partial class PATIENT
	{
		[Column, NotNull] public int    PERSONID  { get; set; } // integer
		[Column, NotNull] public string DIAGNOSIS { get; set; } // varchar(256)

		#region Associations

		/// <summary>
		/// INTEG_7226
		/// </summary>
		[Association(ThisKey="PERSONID", OtherKey="PERSONID", CanBeNull=false)]
		public PERSON INTEG7226 { get; set; }

		#endregion
	}

	[Table("PERSON")]
	public partial class PERSON
	{
		[PrimaryKey, NotNull    ] public int    PERSONID   { get; set; } // integer
		[Column,     NotNull    ] public string FIRSTNAME  { get; set; } // varchar(50)
		[Column,     NotNull    ] public string LASTNAME   { get; set; } // varchar(50)
		[Column,        Nullable] public string MIDDLENAME { get; set; } // varchar(50)
		[Column,     NotNull    ] public string GENDER     { get; set; } // char(1)

		#region Associations

		/// <summary>
		/// FK_DOCTOR_PERSON_BackReference
		/// </summary>
		[Association(ThisKey="PERSONID", OtherKey="PERSONID", CanBeNull=false)]
		public IEnumerable<DOCTOR> DOCTORs { get; set; }

		/// <summary>
		/// INTEG_7226_BackReference
		/// </summary>
		[Association(ThisKey="PERSONID", OtherKey="PERSONID", CanBeNull=false)]
		public IEnumerable<PATIENT> INTEG7226 { get; set; }

		#endregion
	}

	// View
	[Table("PERSONVIEW")]
	public partial class PERSONVIEW
	{
		[Column, Nullable] public int?   PERSONID   { get; set; } // integer
		[Column, Nullable] public string FIRSTNAME  { get; set; } // varchar(50)
		[Column, Nullable] public string LASTNAME   { get; set; } // varchar(50)
		[Column, Nullable] public string MIDDLENAME { get; set; } // varchar(50)
		[Column, Nullable] public string GENDER     { get; set; } // char(1)
	}

	[Table("SEQUENCETEST")]
	public partial class SEQUENCETEST
	{
		[PrimaryKey, NotNull] public int    ID     { get; set; } // integer
		[Column,     NotNull] public string VALUE_ { get; set; } // varchar(50)
	}

	[Table("TESTIDENTITY")]
	public partial class TESTIDENTITY
	{
		[PrimaryKey, NotNull] public int ID { get; set; } // integer
	}

	public static partial class TestDataDBStoredProcedures
	{
		#region OUTREFENUMTEST

		public partial class OUTREFENUMTESTResult
		{
			public string INPUTOUTPUTSTR { get; set; }
			public string OUTPUTSTR      { get; set; }
		}

		public static IEnumerable<OUTREFENUMTESTResult> OUTREFENUMTEST(this DataConnection dataConnection, string STR, string IN_INPUTOUTPUTSTR, out string INPUTOUTPUTSTR, out string OUTPUTSTR)
		{
			var ret = dataConnection.QueryProc<OUTREFENUMTESTResult>("[OUTREFENUMTEST]",
				new DataParameter("STR",               STR),
				new DataParameter("IN_INPUTOUTPUTSTR", IN_INPUTOUTPUTSTR));

			INPUTOUTPUTSTR = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["INPUTOUTPUTSTR"]).Value);
			OUTPUTSTR      = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["OUTPUTSTR"]).     Value);

			return ret;
		}

		#endregion

		#region OUTREFTEST

		public partial class OUTREFTESTResult
		{
			public int?   INPUTOUTPUTID  { get; set; }
			public string INPUTOUTPUTSTR { get; set; }
			public int?   OUTPUTID       { get; set; }
			public string OUTPUTSTR      { get; set; }
		}

		public static IEnumerable<OUTREFTESTResult> OUTREFTEST(this DataConnection dataConnection, int? ID, int? IN_INPUTOUTPUTID, string STR, string IN_INPUTOUTPUTSTR, out int? INPUTOUTPUTID, out string INPUTOUTPUTSTR, out int? OUTPUTID, out string OUTPUTSTR)
		{
			var ret = dataConnection.QueryProc<OUTREFTESTResult>("[OUTREFTEST]",
				new DataParameter("ID",                ID),
				new DataParameter("IN_INPUTOUTPUTID",  IN_INPUTOUTPUTID),
				new DataParameter("STR",               STR),
				new DataParameter("IN_INPUTOUTPUTSTR", IN_INPUTOUTPUTSTR));

			INPUTOUTPUTID  = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["INPUTOUTPUTID"]). Value);
			INPUTOUTPUTSTR = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["INPUTOUTPUTSTR"]).Value);
			OUTPUTID       = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["OUTPUTID"]).      Value);
			OUTPUTSTR      = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["OUTPUTSTR"]).     Value);

			return ret;
		}

		#endregion

		#region PATIENT_SELECTALL

		public partial class PATIENT_SELECTALLResult
		{
			public int?   PERSONID   { get; set; }
			public string FIRSTNAME  { get; set; }
			public string LASTNAME   { get; set; }
			public string MIDDLENAME { get; set; }
			public string GENDER     { get; set; }
			public string DIAGNOSIS  { get; set; }
		}

		public static IEnumerable<PATIENT_SELECTALLResult> PATIENT_SELECTALL(this DataConnection dataConnection, out int? PERSONID, out string FIRSTNAME, out string LASTNAME, out string MIDDLENAME, out string GENDER, out string DIAGNOSIS)
		{
			var ret = dataConnection.QueryProc<PATIENT_SELECTALLResult>("[PATIENT_SELECTALL]");

			PERSONID   = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).  Value);
			FIRSTNAME  = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["FIRSTNAME"]). Value);
			LASTNAME   = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["LASTNAME"]).  Value);
			MIDDLENAME = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["MIDDLENAME"]).Value);
			GENDER     = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["GENDER"]).    Value);
			DIAGNOSIS  = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["DIAGNOSIS"]). Value);

			return ret;
		}

		#endregion

		#region PATIENT_SELECTBYNAME

		public partial class PATIENT_SELECTBYNAMEResult
		{
			public int?   PERSONID   { get; set; }
			public string MIDDLENAME { get; set; }
			public string GENDER     { get; set; }
			public string DIAGNOSIS  { get; set; }
		}

		public static IEnumerable<PATIENT_SELECTBYNAMEResult> PATIENT_SELECTBYNAME(this DataConnection dataConnection, string FIRSTNAME, string LASTNAME, out int? PERSONID, out string MIDDLENAME, out string GENDER, out string DIAGNOSIS)
		{
			var ret = dataConnection.QueryProc<PATIENT_SELECTBYNAMEResult>("[PATIENT_SELECTBYNAME]",
				new DataParameter("FIRSTNAME", FIRSTNAME),
				new DataParameter("LASTNAME",  LASTNAME));

			PERSONID   = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).  Value);
			MIDDLENAME = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["MIDDLENAME"]).Value);
			GENDER     = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["GENDER"]).    Value);
			DIAGNOSIS  = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["DIAGNOSIS"]). Value);

			return ret;
		}

		#endregion

		#region PERSON_DELETE

		public static int PERSON_DELETE(this DataConnection dataConnection, int? PERSONID)
		{
			return dataConnection.ExecuteProc("[PERSON_DELETE]",
				new DataParameter("PERSONID", PERSONID));
		}

		#endregion

		#region PERSON_INSERT

		public partial class PERSON_INSERTResult
		{
			public int? PERSONID { get; set; }
		}

		public static IEnumerable<PERSON_INSERTResult> PERSON_INSERT(this DataConnection dataConnection, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string GENDER, out int? PERSONID)
		{
			var ret = dataConnection.QueryProc<PERSON_INSERTResult>("[PERSON_INSERT]",
				new DataParameter("FIRSTNAME",  FIRSTNAME),
				new DataParameter("LASTNAME",   LASTNAME),
				new DataParameter("MIDDLENAME", MIDDLENAME),
				new DataParameter("GENDER",     GENDER));

			PERSONID = Converter.ChangeTypeTo<int?>(((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).Value);

			return ret;
		}

		#endregion

		#region PERSON_INSERT_OUTPUTPARAMETER

		public partial class PERSON_INSERT_OUTPUTPARAMETERResult
		{
			public int? PERSONID { get; set; }
		}

		public static IEnumerable<PERSON_INSERT_OUTPUTPARAMETERResult> PERSON_INSERT_OUTPUTPARAMETER(this DataConnection dataConnection, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string GENDER, out int? PERSONID)
		{
			var ret = dataConnection.QueryProc<PERSON_INSERT_OUTPUTPARAMETERResult>("[PERSON_INSERT_OUTPUTPARAMETER]",
				new DataParameter("FIRSTNAME",  FIRSTNAME),
				new DataParameter("LASTNAME",   LASTNAME),
				new DataParameter("MIDDLENAME", MIDDLENAME),
				new DataParameter("GENDER",     GENDER));

			PERSONID = Converter.ChangeTypeTo<int?>(((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).Value);

			return ret;
		}

		#endregion

		#region PERSON_SELECTALL

		public static IEnumerable<PERSON> PERSON_SELECTALL(this DataConnection dataConnection, out int? PERSONID, out string FIRSTNAME, out string LASTNAME, out string MIDDLENAME, out string GENDER)
		{
			var ret = dataConnection.QueryProc<PERSON>("[PERSON_SELECTALL]");

			PERSONID   = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).  Value);
			FIRSTNAME  = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["FIRSTNAME"]). Value);
			LASTNAME   = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["LASTNAME"]).  Value);
			MIDDLENAME = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["MIDDLENAME"]).Value);
			GENDER     = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["GENDER"]).    Value);

			return ret;
		}

		#endregion

		#region PERSON_SELECTBYKEY

		public static IEnumerable<PERSON> PERSON_SELECTBYKEY(this DataConnection dataConnection, int? ID, out int? PERSONID, out string FIRSTNAME, out string LASTNAME, out string MIDDLENAME, out string GENDER)
		{
			var ret = dataConnection.QueryProc<PERSON>("[PERSON_SELECTBYKEY]",
				new DataParameter("ID", ID));

			PERSONID   = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).  Value);
			FIRSTNAME  = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["FIRSTNAME"]). Value);
			LASTNAME   = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["LASTNAME"]).  Value);
			MIDDLENAME = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["MIDDLENAME"]).Value);
			GENDER     = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["GENDER"]).    Value);

			return ret;
		}

		#endregion

		#region PERSON_SELECTBYNAME

		public static IEnumerable<PERSON> PERSON_SELECTBYNAME(this DataConnection dataConnection, string IN_FIRSTNAME, string IN_LASTNAME, out int? PERSONID, out string FIRSTNAME, out string LASTNAME, out string MIDDLENAME, out string GENDER)
		{
			var ret = dataConnection.QueryProc<PERSON>("[PERSON_SELECTBYNAME]",
				new DataParameter("IN_FIRSTNAME", IN_FIRSTNAME),
				new DataParameter("IN_LASTNAME",  IN_LASTNAME));

			PERSONID   = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["PERSONID"]).  Value);
			FIRSTNAME  = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["FIRSTNAME"]). Value);
			LASTNAME   = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["LASTNAME"]).  Value);
			MIDDLENAME = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["MIDDLENAME"]).Value);
			GENDER     = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["GENDER"]).    Value);

			return ret;
		}

		#endregion

		#region PERSON_UPDATE

		public static int PERSON_UPDATE(this DataConnection dataConnection, int? PERSONID, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string GENDER)
		{
			return dataConnection.ExecuteProc("[PERSON_UPDATE]",
				new DataParameter("PERSONID",   PERSONID),
				new DataParameter("FIRSTNAME",  FIRSTNAME),
				new DataParameter("LASTNAME",   LASTNAME),
				new DataParameter("MIDDLENAME", MIDDLENAME),
				new DataParameter("GENDER",     GENDER));
		}

		#endregion

		#region SCALAR_DATAREADER

		public partial class SCALAR_DATAREADERResult
		{
			public int?   INTFIELD    { get; set; }
			public string STRINGFIELD { get; set; }
		}

		public static IEnumerable<SCALAR_DATAREADERResult> SCALAR_DATAREADER(this DataConnection dataConnection, out int? INTFIELD, out string STRINGFIELD)
		{
			var ret = dataConnection.QueryProc<SCALAR_DATAREADERResult>("[SCALAR_DATAREADER]");

			INTFIELD    = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["INTFIELD"]).   Value);
			STRINGFIELD = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["STRINGFIELD"]).Value);

			return ret;
		}

		#endregion

		#region SCALAR_OUTPUTPARAMETER

		public partial class SCALAR_OUTPUTPARAMETERResult
		{
			public int?   OUTPUTINT    { get; set; }
			public string OUTPUTSTRING { get; set; }
		}

		public static IEnumerable<SCALAR_OUTPUTPARAMETERResult> SCALAR_OUTPUTPARAMETER(this DataConnection dataConnection, out int? OUTPUTINT, out string OUTPUTSTRING)
		{
			var ret = dataConnection.QueryProc<SCALAR_OUTPUTPARAMETERResult>("[SCALAR_OUTPUTPARAMETER]");

			OUTPUTINT    = Converter.ChangeTypeTo<int?>  (((IDbDataParameter)dataConnection.Command.Parameters["OUTPUTINT"]).   Value);
			OUTPUTSTRING = Converter.ChangeTypeTo<string>(((IDbDataParameter)dataConnection.Command.Parameters["OUTPUTSTRING"]).Value);

			return ret;
		}

		#endregion

		#region SCALAR_RETURNPARAMETER

		public partial class SCALAR_RETURNPARAMETERResult
		{
			public int? RETURN_VALUE { get; set; }
		}

		public static IEnumerable<SCALAR_RETURNPARAMETERResult> SCALAR_RETURNPARAMETER(this DataConnection dataConnection, out int? RETURN_VALUE)
		{
			var ret = dataConnection.QueryProc<SCALAR_RETURNPARAMETERResult>("[SCALAR_RETURNPARAMETER]");

			RETURN_VALUE = Converter.ChangeTypeTo<int?>(((IDbDataParameter)dataConnection.Command.Parameters["RETURN_VALUE"]).Value);

			return ret;
		}

		#endregion
	}
}
