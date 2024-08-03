using Log.Layer.Business;
using Log.Layer.Model.Model;
using Log.Layer.Model.Model.Enumerator;
using Log.Layer.Model.Extension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using Log.Layer.Data;
using System.Runtime.CompilerServices;

namespace Log.Layer.Presentation.Test
{
    internal class Program
    {
        static string requestC = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfOracleParameter xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pCAMBIA_ESTATUS</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pSEGUIMIENTO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTIPO_DOCUMENTO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>1</Size>\r\n    <Value xsi:type=\"xsd:string\"> </Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREMITENTE_EXTERNO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTIPO_USUARIO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>1</Size>\r\n    <Value xsi:type=\"xsd:string\">S</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREMITENTE_EXT_CATALOGO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTIPO_DOCUMENTO_CATALOGO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREM_INCLUYE_OPER</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTUR_ARBOL</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pCONFIRMA_CONCLUIR</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pCONCLUIR_ACUSE_CCPARA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pRESPONDER_CASCADA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_EMPLEADO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">134961</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_REMITENTE_AREA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">931</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_REMITENTE_TITULAR</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">137701</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_DESTINATARIO_AREA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_DESTINATARIO_TITULAR</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_FIRMA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_FOLIO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_TIPO_DOCUMENTO_EMPLEADO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_TIPO_DOCUMENTO_AREA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_REMITENTE_EXTERNO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pDOCUMENTO_TIPO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>3</Size>\r\n    <Value xsi:type=\"xsd:string\">Emp</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pELIMINADO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>1</Size>\r\n    <Value xsi:type=\"xsd:string\">0</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pFECHA_INICIO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>10</Size>\r\n    <Value xsi:type=\"xsd:string\">30/07/2024</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pFECHA_FIN</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>10</Size>\r\n    <Value xsi:type=\"xsd:string\">31/12/2049</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n</ArrayOfOracleParameter>";
        static string requestU = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfOracleParameter xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREGLA_ID</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">1022</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pCAMBIA_ESTATUS</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">Si</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pSEGUIMIENTO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTIPO_DOCUMENTO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>1</Size>\r\n    <Value xsi:type=\"xsd:string\"> </Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREMITENTE_EXTERNO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTIPO_USUARIO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>1</Size>\r\n    <Value xsi:type=\"xsd:string\">S</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREMITENTE_EXT_CATALOGO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTIPO_DOCUMENTO_CATALOGO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pREM_INCLUYE_OPER</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">Si</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pTUR_ARBOL</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">Si</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pCONFIRMA_CONCLUIR</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pCONCLUIR_ACUSE_CCPARA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">No</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pRESPONDER_CASCADA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>2</Size>\r\n    <Value xsi:type=\"xsd:string\">Si</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_EMPLEADO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">13451</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_REMITENTE_AREA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">543</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_REMITENTE_TITULAR</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">13451</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_DESTINATARIO_AREA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">543</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_DESTINATARIO_TITULAR</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">13451</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_FIRMA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">13451</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_FOLIO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">543</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_TIPO_DOCUMENTO_EMPLEADO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">6484</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_TIPO_DOCUMENTO_AREA</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>VarNumeric</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pID_REMITENTE_EXTERNO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">6484</Value>\r\n    <OracleType>Number</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pDOCUMENTO_TIPO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>3</Size>\r\n    <Value xsi:type=\"xsd:string\">Emp</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pELIMINADO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>1</Size>\r\n    <Value xsi:type=\"xsd:string\">0</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pFECHA_INICIO</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>10</Size>\r\n    <Value xsi:type=\"xsd:string\">30/07/2024</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pFECHA_FIN</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>10</Size>\r\n    <Value xsi:type=\"xsd:string\">31/12/2049</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n</ArrayOfOracleParameter>";
        static string requestD = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfOracleParameter xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <OracleParameter>\r\n    <DbType>Int32</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pReglaId</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>0</Size>\r\n    <Value xsi:type=\"xsd:int\">0</Value>\r\n    <OracleType>Int32</OracleType>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n  <OracleParameter>\r\n    <DbType>AnsiString</DbType>\r\n    <IsNullable>false</IsNullable>\r\n    <ParameterName>pEndDate</ParameterName>\r\n    <Precision>0</Precision>\r\n    <Scale>0</Scale>\r\n    <Size>10</Size>\r\n    <Value xsi:type=\"xsd:string\">30/07/2024</Value>\r\n    <Offset>0</Offset>\r\n  </OracleParameter>\r\n</ArrayOfOracleParameter>";
        /// <summary>
        /// Antes de probar
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //GetRegla(838, "", "");
            Create("1", "11");
            Update("1", "11");
            //Remove(1, "11", "1", "11");
        }

        public static DataSet GetRegla(int ruleId, string uid, string ip)
        {
            string sAlias = "sof_empleados sof_rem_emp, " +
                            "sof_empleados sof_des_emp, " +
                            "sof_areas sof_rem_area, " +
                            "sof_areas sof_des_area, sof_empleados sof_sign, sof_areas sof_folio, " +
                            "sof_empleados sof_tipo_doc_emp, " +
                            "sof_areas sof_tipo_doc_area, " +
                            "sof_empleados sof_rem_ext_emp, " +
                            "sof_areas sof_rem_ext_area ";

            string sSql = "Select sof_regla.*, sof_rem_emp.nombre remitenteNombre, sof_des_emp.nombre destinatarioNombre, " +
                            "sof_rem_area.area remitenteArea, sof_des_area.area destinatarioArea, " +
                            "sof_rem_area.cve_area RemitenteClaveArea, sof_des_area.cve_area DestinatarioClaveArea, " +
                            "sof_sign.nombre signNombre, sof_folio.cve_area folioClaveArea, sof_folio.area folioArea, " +
                            "sof_empleados.nombre usuarioNombre, " +
                            "sof_tipo_doc_emp.apellidonombre tipo_doc_emp, " +
                            "sof_tipo_doc_area.area tipo_doc_area, " +
                            "decode(nvl(sof_regla.id_remitente_externo,0),0, sof_rem_ext_area.area,  sof_rem_ext_emp.apellidonombre) rem_ext " +
                            "From sof_regla, sof_empleados, " + sAlias +
                            " Where 1=1" +
                            " And sof_regla.regla_id = " + ruleId +
                            " And sof_empleados.id_empleado = sof_regla.id_empleado " +
                            " And sof_rem_emp.id_empleado = sof_regla.id_remitente_titular " +
                            " And sof_des_emp.id_empleado = sof_regla.id_destinatario_titular " +
                            " And sof_rem_area.id_area = sof_regla.id_remitente_area " +
                            " And sof_des_area.id_area = sof_regla.id_destinatario_area " +
                            " And sof_regla.id_firma = sof_sign.id_empleado " +
                            " And sof_regla.id_folio = sof_folio.id_area " +
                            " And sof_tipo_doc_emp.id_empleado(+) = sof_regla.id_tipo_documento_empleado " +
                            " And sof_tipo_doc_area.id_area(+) = sof_regla.id_tipo_documento_area " +
                            " And sof_rem_ext_emp.id_empleado(+) = sof_regla.ID_REMITENTE_EXTERNO " +
                            " And sof_rem_ext_area.id_area(+) = sof_empleados.id_area ";
            DataSet ds = OracleHelper.ExecuteDataset(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, sSql);
            #region LOG
            var metadata = ControlLog.GetInstance().GetMetadata(null, null
                    , new List<Item> { new Item { text = "Regla", value = "REGLA_ID" } }
                    , null, enuActionTrack.Retrieve, ds
                    );
            ControlLog.GetInstance().Create(
                new LogSystem(Convert.ToInt32(uid), "Pantalla Vista de Reglas / Editor de Regla", enuAction.Retrieve.GetDescription(), "sof_regla, sof_empleados", sSql, ip,Guid.NewGuid().ToString(), "1",metadata.result));
            #endregion
            return ds;
        }
        public static int Create(
            /*string CAMBIA_ESTATUS,
            string SEGUIMIENTO,
            string TIPO_DOCUMENTO,
            string REMITENTE_EXTERNO,
            string TIPO_USUARIO,
            string REMITENTE_EXT_CATALOGO,
            string TIPO_DOCUMENTO_CATALOGO,
            string REM_INCLUYE_OPER,
            string TUR_ARBOL,
            string CONFIRMA_CONCLUIR,
            string CONCLUIR_ACUSE_CCPARA,
            string RESPONDER_CASCADA,
            int ID_EMPLEADO,
            int ID_REMITENTE_AREA,
            int ID_REMITENTE_TITULAR,
            int ID_DESTINATARIO_AREA,
            int ID_DESTINATARIO_TITULAR,
            int ID_FIRMA,
            int ID_FOLIO,
            int ID_TIPO_DOCUMENTO_EMPLEADO,
            int ID_TIPO_DOCUMENTO_AREA,
            int ID_REMITENTE_EXTERNO,
            string DOCUMENTO_TIPO,
            string ELIMINADO,
            string FECHA_INICIO,
            string FECHA_FIN*/
            string uid, string ip
            )
        {

            #region old
            /*OracleParameter[] oParam = {
                                                new OracleParameter("pCAMBIA_ESTATUS", OracleType.VarChar),
                                                new OracleParameter("pSEGUIMIENTO", OracleType.VarChar),
                                                new OracleParameter("pTIPO_DOCUMENTO", OracleType.VarChar),
                                                new OracleParameter("pREMITENTE_EXTERNO", OracleType.VarChar),
                                                new OracleParameter("pTIPO_USUARIO", OracleType.VarChar),
                                                new OracleParameter("pREMITENTE_EXT_CATALOGO", OracleType.VarChar),
                                                new OracleParameter("pTIPO_DOCUMENTO_CATALOGO", OracleType.VarChar),
                                                new OracleParameter("pREM_INCLUYE_OPER", OracleType.VarChar),
                                                new OracleParameter("pTUR_ARBOL", OracleType.VarChar),
                                                new OracleParameter("pCONFIRMA_CONCLUIR", OracleType.VarChar),
                                                new OracleParameter("pCONCLUIR_ACUSE_CCPARA", OracleType.VarChar),
                                                new OracleParameter("pRESPONDER_CASCADA", OracleType.VarChar),
                                                new OracleParameter("pID_EMPLEADO", null),
                                                new OracleParameter("pID_REMITENTE_AREA", null),
                                                new OracleParameter("pID_REMITENTE_TITULAR", null),
                                                new OracleParameter("pID_DESTINATARIO_AREA", null),
                                                new OracleParameter("pID_DESTINATARIO_TITULAR", null),
                                                new OracleParameter("pID_FIRMA", null),
                                                new OracleParameter("pID_FOLIO", null),
                                                new OracleParameter("pID_TIPO_DOCUMENTO_EMPLEADO", null),
                                                new OracleParameter("pID_TIPO_DOCUMENTO_AREA", null),
                                                new OracleParameter("pID_REMITENTE_EXTERNO", null),
                                                new OracleParameter("pDOCUMENTO_TIPO",OracleType.VarChar),
                                                new OracleParameter("pELIMINADO",OracleType.VarChar),
                                                new OracleParameter("pFECHA_INICIO",OracleType.VarChar),
                                                new OracleParameter("pFECHA_FIN",OracleType.VarChar)
                                            };

                oParam[0].Value = CAMBIA_ESTATUS;
                oParam[1].Value = SEGUIMIENTO;
                oParam[2].Value = TIPO_DOCUMENTO;
                oParam[3].Value = REMITENTE_EXTERNO;
                oParam[4].Value = TIPO_USUARIO;
                oParam[5].Value = REMITENTE_EXT_CATALOGO;
                oParam[6].Value = TIPO_DOCUMENTO_CATALOGO;
                oParam[7].Value = REM_INCLUYE_OPER;
                oParam[8].Value = TUR_ARBOL;
                oParam[9].Value = CONFIRMA_CONCLUIR;
                oParam[10].Value = CONCLUIR_ACUSE_CCPARA;
                oParam[11].Value = RESPONDER_CASCADA;
                oParam[12].Value = ID_EMPLEADO;
                oParam[13].Value = ID_REMITENTE_AREA;
                oParam[14].Value = ID_REMITENTE_TITULAR;
                oParam[15].Value = ID_DESTINATARIO_AREA;
                oParam[16].Value = ID_DESTINATARIO_TITULAR;
                oParam[17].Value = ID_FIRMA;
                oParam[18].Value = ID_FOLIO;
                oParam[19].Value = ID_TIPO_DOCUMENTO_EMPLEADO;
                oParam[20].Value = ID_TIPO_DOCUMENTO_AREA;
                oParam[21].Value = ID_REMITENTE_EXTERNO;
                oParam[22].Value = DOCUMENTO_TIPO;
                oParam[23].Value = ELIMINADO;
                oParam[24].Value = FECHA_INICIO;
                oParam[25].Value = FECHA_FIN;
                */ 
            #endregion
            OracleParameter[] oParam = requestC.DeserializeOracleParameters();
            OracleHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, "sp_regla_create", oParam);
            
            #region Log
            List<Item> fieldMetadata = new List<Item> {
                { new Item { label="Al imprimir el volante cambia de Pendiente a Trámite?", text ="CAMBIA_ESTATUS", value = "pCAMBIA_ESTATUS" } },
                { new Item { label="Seguimiento Externo? ", text ="SEGUIMIENTO", value = "pSEGUIMIENTO" } },
                { new Item { label="Los Tipo Documento son por Empleado?", text ="TIPO_DOCUMENTO", value = "pTIPO_DOCUMENTO" } },
                { new Item { label="Los Remitentes Externos son por Empleado?", text ="REMITENTE_EXTERNO", value = "pREMITENTE_EXTERNO" } },
                { new Item { label="Tipo Usuario", text ="TIPO_USUARIO", value = "pTIPO_USUARIO" } },
                { new Item { label=" Usa Catálogo Remitente Externo", text ="REMITENTE_EXT_CATALOGO", value = "pREMITENTE_EXT_CATALOGO" } },
                { new Item { label="Usa Catálogo Tipo Documento?", text ="TIPO_DOCUMENTO_CATALOGO", value = "pTIPO_DOCUMENTO_CATALOGO" } },
                { new Item { label="Remitente Incluye Operativos? ", text ="REM_INCLUYE_OPER", value = "pREM_INCLUYE_OPER" } },
                { new Item { label=" Al Turnar Despliega Operativos?", text ="TUR_ARBOL", value = "pTUR_ARBOL" } },
                { new Item { label="Confirna Concluir, el Volante? ", text ="CONFIRMA_CONCLUIR", value = "pCONFIRMA_CONCLUIR" } },
                { new Item { label="Se concluye un volante al acusar de recibo un turno con copia", text ="CONCLUIR_ACUSE_CCPARA", value = "pCONCLUIR_ACUSE_CCPARA" } },
                { new Item { label="La Respuesta es en Cascada? ", text ="RESPONDER_CASCADA", value = "pRESPONDER_CASCADA" } },
                { new Item { label="Usuario", text ="ID_EMPLEADO", value = "pID_EMPLEADO",sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}" } },
                { new Item { label="Remitente Area", text ="ID_REMITENTE_AREA", value = "pID_REMITENTE_AREA" , sentence = "select area \"text\" From sof_Areas WHERE id_area={0}"} },
                { new Item { label="Remitente", text ="ID_REMITENTE_TITULAR", value = "pID_REMITENTE_TITULAR" ,sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}"} },
                { new Item { label="Destinatario Area", text ="ID_DESTINATARIO_AREA", value = "pID_DESTINATARIO_AREA", sentence = "select area \"text\" From sof_Areas WHERE id_area={0}" } },
                { new Item { label="Destinatario", text ="ID_DESTINATARIO_TITULAR", value = "pID_DESTINATARIO_TITULAR",sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}" } },
                { new Item { label="Firma", text ="ID_FIRMA", value = "pID_FIRMA",sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}" } },
                { new Item { label="Folio", text ="ID_FOLIO", value = "pID_FOLIO" , sentence = "select area \"text\" From sof_Areas WHERE id_area={0}"} },
                { new Item { label="Tipo Documento Empleado", text ="ID_TIPO_DOCUMENTO_EMPLEADO", value = "pID_TIPO_DOCUMENTO_EMPLEADO" ,sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}"} },
                { new Item { label="Tipo Documento Empleado Area", text ="ID_TIPO_DOCUMENTO_AREA", value = "pID_TIPO_DOCUMENTO_AREA", sentence = "select area \"text\" From sof_Areas WHERE id_area={0}" } },
                { new Item { label="Remitente Externo", text ="ID_REMITENTE_EXTERNO", value = "pID_REMITENTE_EXTERNO" ,sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}"} },
                { new Item { label="Remitente Externo Area", text ="DOCUMENTO_TIPO", value = "pDOCUMENTO_TIPO" } },
                { new Item { label="Eliminado", text ="ELIMINADO", value = "pELIMINADO" } },
                { new Item { label="Fecha de Vigencia", text ="FECHA_INICIO", value = "pFECHA_INICIO" } },
                { new Item { label="Fecha de Vigencia Fin", text ="FECHA_FIN", value = "pFECHA_FIN" } }
            };
            var metadata = ControlLog.GetInstance().GetMetadata(oParam, null
                , fieldMetadata
                , null, enuActionTrack.Create
                );
            ControlLog.GetInstance().Create(
                new LogSystem(Convert.ToInt32(uid), "Pantalla Vista de Reglas / Editor de Reglas", enuAction.Create.GetDescription(), "sp_regla_create", string.Join(",", oParam.ToList()), ip, Guid.NewGuid().ToString(), "1", metadata.result));
            #endregion

            return 1;
        }

        public static void Update(
            /*int REGLA_ID,
            string CAMBIA_ESTATUS,
            string SEGUIMIENTO,
            string TIPO_DOCUMENTO,
            string REMITENTE_EXTERNO,
            string TIPO_USUARIO,
            string REMITENTE_EXT_CATALOGO,
            string TIPO_DOCUMENTO_CATALOGO,
            string REM_INCLUYE_OPER,
            string TUR_ARBOL,
            string CONFIRMA_CONCLUIR,
            string CONCLUIR_ACUSE_CCPARA,
            string RESPONDER_CASCADA,
            int ID_EMPLEADO,
            int ID_REMITENTE_AREA,
            int ID_REMITENTE_TITULAR,
            int ID_DESTINATARIO_AREA,
            int ID_DESTINATARIO_TITULAR,
            int ID_FIRMA,
            int ID_FOLIO,
            int ID_TIPO_DOCUMENTO_EMPLEADO,
            int ID_TIPO_DOCUMENTO_AREA,
            int ID_REMITENTE_EXTERNO,
            string DOCUMENTO_TIPO,
            string ELIMINADO,
            string FECHA_INICIO,
            string FECHA_FIN*/
            string uid, string ip
            )
        {
            #region old
            /*OracleParameter[] oParam = {
                                                new OracleParameter("pREGLA_ID", OracleType.Number),
                                                new OracleParameter("pCAMBIA_ESTATUS", OracleType.VarChar),
                                                new OracleParameter("pSEGUIMIENTO", OracleType.VarChar),
                                                new OracleParameter("pTIPO_DOCUMENTO", OracleType.VarChar),
                                                new OracleParameter("pREMITENTE_EXTERNO", OracleType.VarChar),
                                                new OracleParameter("pTIPO_USUARIO", OracleType.VarChar),
                                                new OracleParameter("pREMITENTE_EXT_CATALOGO", OracleType.VarChar),
                                                new OracleParameter("pTIPO_DOCUMENTO_CATALOGO", OracleType.VarChar),
                                                new OracleParameter("pREM_INCLUYE_OPER", OracleType.VarChar),
                                                new OracleParameter("pTUR_ARBOL", OracleType.VarChar),
                                                new OracleParameter("pCONFIRMA_CONCLUIR", OracleType.VarChar),
                                                new OracleParameter("pCONCLUIR_ACUSE_CCPARA", OracleType.VarChar),
                                                new OracleParameter("pRESPONDER_CASCADA", OracleType.VarChar),
                                                new OracleParameter("pID_EMPLEADO", OracleType.Number),
                                                new OracleParameter("pID_REMITENTE_AREA", OracleType.Number),
                                                new OracleParameter("pID_REMITENTE_TITULAR", OracleType.Number),
                                                new OracleParameter("pID_DESTINATARIO_AREA", OracleType.Number),
                                                new OracleParameter("pID_DESTINATARIO_TITULAR", OracleType.Number),
                                                new OracleParameter("pID_FIRMA", OracleType.Number),
                                                new OracleParameter("pID_FOLIO", OracleType.Number),
                                                new OracleParameter("pID_TIPO_DOCUMENTO_EMPLEADO", OracleType.Number),
                                                new OracleParameter("pID_TIPO_DOCUMENTO_AREA", OracleType.Number),
                                                new OracleParameter("pID_REMITENTE_EXTERNO", OracleType.Number),
                                                new OracleParameter("pDOCUMENTO_TIPO",OracleType.VarChar),
                                                new OracleParameter("pELIMINADO",OracleType.VarChar),
                                                new OracleParameter("pFECHA_INICIO",OracleType.VarChar),
                                                new OracleParameter("pFECHA_FIN",OracleType.VarChar)
                                            };            
                oParam[0].Value = REGLA_ID;
                oParam[1].Value = CAMBIA_ESTATUS;
                oParam[2].Value = SEGUIMIENTO;
                oParam[3].Value = TIPO_DOCUMENTO;
                oParam[4].Value = REMITENTE_EXTERNO;
                oParam[5].Value = TIPO_USUARIO;
                oParam[6].Value = REMITENTE_EXT_CATALOGO;
                oParam[7].Value = TIPO_DOCUMENTO_CATALOGO;
                oParam[8].Value = REM_INCLUYE_OPER;
                oParam[9].Value = TUR_ARBOL;
                oParam[10].Value = CONFIRMA_CONCLUIR;
                oParam[11].Value = CONCLUIR_ACUSE_CCPARA;
                oParam[12].Value = RESPONDER_CASCADA;
                oParam[13].Value = ID_EMPLEADO;
                oParam[14].Value = ID_REMITENTE_AREA;
                oParam[15].Value = ID_REMITENTE_TITULAR;
                oParam[16].Value = ID_DESTINATARIO_AREA;
                oParam[17].Value = ID_DESTINATARIO_TITULAR;
                oParam[18].Value = ID_FIRMA;
                oParam[19].Value = ID_FOLIO;
                oParam[20].Value = ID_TIPO_DOCUMENTO_EMPLEADO;
                oParam[21].Value = ID_TIPO_DOCUMENTO_AREA;
                oParam[22].Value = ID_REMITENTE_EXTERNO;
                oParam[23].Value = DOCUMENTO_TIPO;
                oParam[24].Value = ELIMINADO;
                oParam[25].Value = FECHA_INICIO;
                oParam[26].Value = FECHA_FIN;*/

            #endregion
            OracleParameter[] oParam = requestU.DeserializeOracleParameters();
            #region Log
            OracleParameter[] oParamMetadata = {
                                            new OracleParameter("pREGLA_ID", OracleType.Number),
                                            new OracleParameter("outCursor", OracleType.Cursor)};
            List<Item> fieldMetadata = new List<Item> {
            { new Item { label="Al imprimir el volante cambia de Pendiente a Trámite?", text ="CAMBIA_ESTATUS", value = "pCAMBIA_ESTATUS" } },
            { new Item { label="Seguimiento Externo? ", text ="SEGUIMIENTO", value = "pSEGUIMIENTO" } },
            { new Item { label="Los Tipo Documento son por Empleado?", text ="TIPO_DOCUMENTO", value = "pTIPO_DOCUMENTO" } },
            { new Item { label="Los Remitentes Externos son por Empleado?", text ="REMITENTE_EXTERNO", value = "pREMITENTE_EXTERNO" } },
            { new Item { label="Tipo Usuario", text ="TIPO_USUARIO", value = "pTIPO_USUARIO" } },
            { new Item { label=" Usa Catálogo Remitente Externo", text ="REMITENTE_EXT_CATALOGO", value = "pREMITENTE_EXT_CATALOGO" } },
            { new Item { label="Usa Catálogo Tipo Documento?", text ="TIPO_DOCUMENTO_CATALOGO", value = "pTIPO_DOCUMENTO_CATALOGO" } },
            { new Item { label="Remitente Incluye Operativos? ", text ="REM_INCLUYE_OPER", value = "pREM_INCLUYE_OPER" } },
            { new Item { label=" Al Turnar Despliega Operativos?", text ="TUR_ARBOL", value = "pTUR_ARBOL" } },
            { new Item { label="Confirna Concluir, el Volante? ", text ="CONFIRMA_CONCLUIR", value = "pCONFIRMA_CONCLUIR" } },
            { new Item { label="Se concluye un volante al acusar de recibo un turno con copia", text ="CONCLUIR_ACUSE_CCPARA", value = "pCONCLUIR_ACUSE_CCPARA" } },
            { new Item { label="La Respuesta es en Cascada? ", text ="RESPONDER_CASCADA", value = "pRESPONDER_CASCADA" } },
            { new Item { label="Usuario", text ="ID_EMPLEADO", value = "pID_EMPLEADO",sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}" } },
            { new Item { label="Remitente Area", text ="ID_REMITENTE_AREA", value = "pID_REMITENTE_AREA" , sentence = "select area \"text\" From sof_Areas WHERE id_area={0}"} },
            { new Item { label="Remitente", text ="ID_REMITENTE_TITULAR", value = "pID_REMITENTE_TITULAR" ,sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}"} },
            { new Item { label="Destinatario Area", text ="ID_DESTINATARIO_AREA", value = "pID_DESTINATARIO_AREA", sentence = "select area \"text\" From sof_Areas WHERE id_area={0}" } },
            { new Item { label="Destinatario", text ="ID_DESTINATARIO_TITULAR", value = "pID_DESTINATARIO_TITULAR",sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}" } },
            { new Item { label="Firma", text ="ID_FIRMA", value = "pID_FIRMA",sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}" } },
            { new Item { label="Folio", text ="ID_FOLIO", value = "pID_FOLIO" , sentence = "select area \"text\" From sof_Areas WHERE id_area={0}"} },
            { new Item { label="Tipo Documento Empleado", text ="ID_TIPO_DOCUMENTO_EMPLEADO", value = "pID_TIPO_DOCUMENTO_EMPLEADO" ,sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}"} },
            { new Item { label="Tipo Documento Empleado Area", text ="ID_TIPO_DOCUMENTO_AREA", value = "pID_TIPO_DOCUMENTO_AREA", sentence = "select area \"text\" From sof_Areas WHERE id_area={0}" } },
            { new Item { label="Remitente Externo", text ="ID_REMITENTE_EXTERNO", value = "pID_REMITENTE_EXTERNO" ,sentence="SELECT nombre \"text\" FROM sof_empleados WHERE ID_EMPLEADO ={0}"} },
            { new Item { label="Remitente Externo Area", text ="DOCUMENTO_TIPO", value = "pDOCUMENTO_TIPO" } },
            { new Item { label="Eliminado", text ="ELIMINADO", value = "pELIMINADO" } },
            { new Item { label="Fecha de Vigencia", text ="FECHA_INICIO", value = "pFECHA_INICIO" } }
            };
            oParamMetadata[0].Value = oParam[0].Value;
            oParamMetadata[1].Direction = ParameterDirection.Output;
            var metadata = ControlLog.GetInstance().GetMetadata(oParam, oParamMetadata
                , fieldMetadata
                , "SP_REGLA_UPDATE_LOG", enuActionTrack.Update
                );
            #endregion
            OracleHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["ConnectionString"],CommandType.StoredProcedure, "sp_regla_update", oParam);
            #region Log
            ControlLog.GetInstance().Create(
                new LogSystem(Convert.ToInt32(uid), "Pantalla Vista de Reglas / Editor de Reglas", enuAction.Update.GetDescription(), "sp_regla_update", string.Join(",", oParam.Select(x => string.Format("{0}={1}", x.ParameterName, x.Value)).ToList()), ip, Guid.NewGuid().ToString(), "1", metadata.result));
            #endregion

        }

        public static void Remove(int ruleId, string endDate, string uid, string ip)
        {

            #region old
            //OracleParameter[] oParam = {new OracleParameter("pReglaId", null),
            //                             new OracleParameter("pEndDate",OracleType.VarChar)
            //                            };

            //oParam[0].Value = ruleId;
            //oParam[1].Value = endDate; 
            #endregion
            OracleParameter[] oParam = requestD.DeserializeOracleParameters();
            OracleHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, "sp_regla_remove", oParam);

            #region Log
            var metadata = ControlLog.GetInstance().GetMetadata(null, null
        , new List<Item> { new Item { text = "Regla", value = "pReglaId" }, new Item { text = "Fecha Fin", value = "pEndDate" } }
        , null, enuActionTrack.Delete, null
        );
            ControlLog.GetInstance().Create(
            new LogSystem(Convert.ToInt32(uid), "Pantalla Vista de Reglas / Editor de Reglas", enuAction.Delete.GetDescription(), "sp_regla_remove", string.Join(",", oParam.ToList()), ip, Guid.NewGuid().ToString(), "1", metadata.result)); 
            #endregion
        }
    }
}
