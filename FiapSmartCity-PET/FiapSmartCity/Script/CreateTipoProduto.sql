﻿use FIAPSmartCity

CREATE TABLE TIPOPRODUTO (
      IDTIPO    int identity(1,1)        PRIMARY KEY,
      DESCRICAOTIPO VARCHAR(50)  NOT NULL,
      COMERCIALIZADO  CHAR(1)
    );