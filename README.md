--**************************** SCRIPT BD ***************************
/*
PONER ATENCION EN LOS ESQUEMAS DE LOS SIGUIENTES 
SCRIPTS Y AJUSTAR EN "Log.Layer.Business.ControlLog"
*/

--************* CREA SECUENCIA *************
CREATE SEQUENCE LOGSYSTEM_LogId_SEQ START WITH 1 INCREMENT BY 1 NoCache NoCycle;

--************* CREA TABLA *************
CREATE TABLE CGESTION.LOGSYSTEM (
	LOGID INTEGER NOT NULL,
	USERID INTEGER NULL,
	DATETIMEEVENT DATE NULL,
	MODULE VARCHAR2(500) NULL,
	"ACTION" VARCHAR2(100) NULL,
	ISDB CHAR(1) NULL,
	"TABLE" VARCHAR2(100) NULL,
	SENTENCE VARCHAR2(4000) NULL,
	IP VARCHAR2(100) NULL,
	METADATA VARCHAR2(4000) NULL,
	CONSTRAINT LOGSYSTEM_PK PRIMARY KEY (LOGID)
)
TABLESPACE SISTEMAS_GESTION;

--************* CREA TRIGGER *************
CREATE OR REPLACE TRIGGER Trg_Insert_LOGSYSTEM_LogId
BEFORE INSERT ON CGESTION.LOGSYSTEM
FOR EACH ROW
BEGIN
  IF :NEW.LOGID IS NULL THEN
    SELECT LOGSYSTEM_LogId_SEQ.NEXTVAL INTO :NEW.LOGID FROM dual;
  END IF;
END;


--**************************** CONSIDERACIONES ***************************

1.- REVISAR LOS SETTINGS DE ESTE PROYECTO PARA MODIFICAR "ConnectionString" APUNTANDO A LA BD DESEADA
2.- DEL AJUSTE ANTERIOR ASEGURARSE EXISTAN LOS OBJETOS DE SCRIPTS DE SECCION PREVIA

