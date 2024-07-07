CREATE TABLE StatusNota (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Descricao NVARCHAR(50) NOT NULL
);

INSERT INTO StatusNota (Descricao)
VALUES ('Emitida'),
       ('Cobrança realizada'),
       ('Pagamento em atraso'),
       ('Pagamento realizado');



CREATE TABLE TipoPagamento (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Descricao NVARCHAR(50) NOT NULL
);

INSERT INTO TipoPagamento (Descricao)
VALUES ('PIX'),
       ('Boleto Bancário'),
       ('Cartão de Crédito'),
       ('Transferência Bancária');



CREATE TABLE Pagador (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Nome NVARCHAR(100) NOT NULL
);

INSERT INTO Pagador (Nome)
VALUES ('Empresa A'),
       ('Empresa B'),
       ('Empresa C');



CREATE TABLE NotaFiscal (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    PagadorId INT NOT NULL,
    NumeroIdentificacao NVARCHAR(50) NOT NULL,
    DataEmissao DATE NOT NULL,
    DataCobranca DATE NULL,
    DataPagamento DATE NULL,
    Valor DECIMAL(18, 2) NOT NULL,
    DocumentoNotaFiscal NVARCHAR(MAX) NULL,
    DocumentoBoletoBancario NVARCHAR(MAX) NULL,
    StatusNotaId INT NOT NULL,
    TipoPagamentoId INT NULL,
    FOREIGN KEY (PagadorId) REFERENCES Pagador(Id),
    FOREIGN KEY (StatusNotaId) REFERENCES StatusNota(Id),
    FOREIGN KEY (TipoPagamentoId) REFERENCES TipoPagamento(Id)
);

INSERT INTO NotaFiscal (
    PagadorId,
    NumeroIdentificacao,
    DataEmissao,
    DataCobranca,
    DataPagamento,
    Valor,
    DocumentoNotaFiscal,
    DocumentoBoletoBancario,
    StatusNotaId,
    TipoPagamentoId
)
VALUES 
    (1, 'NF001', '2023-01-15', '2023-02-15', '2023-02-20', 1000.00, 'DocumentoNF001.pdf', 'BoletoNF001.pdf', 1, 1),
    (2, 'NF002', '2023-01-25', '2023-02-25', NULL, 1500.00, 'DocumentoNF002.pdf', 'BoletoNF002.pdf', 2, 2),
    (3, 'NF003', '2023-01-10', NULL, NULL, 1200.00, 'DocumentoNF003.pdf', 'BoletoNF003.pdf', 3, NULL),

    (2, 'NF004', '2023-02-05', '2023-03-05', '2023-03-10', 1800.00, 'DocumentoNF004.pdf', 'BoletoNF004.pdf', 4, 1),
    (1, 'NF005', '2023-02-20', '2023-03-20', NULL, 2000.00, 'DocumentoNF005.pdf', 'BoletoNF005.pdf', 1, 2),
    (3, 'NF006', '2023-02-28', NULL, NULL, 1700.00, 'DocumentoNF006.pdf', 'BoletoNF006.pdf', 2, NULL),

    (3, 'NF007', '2023-03-10', '2023-04-10', '2023-04-15', 1300.00, 'DocumentoNF007.pdf', 'BoletoNF007.pdf', 3, 4),
    (1, 'NF008', '2023-03-15', '2023-04-15', NULL, 2200.00, 'DocumentoNF008.pdf', 'BoletoNF008.pdf', 4, 1),
    (2, 'NF009', '2023-03-25', NULL, NULL, 1900.00, 'DocumentoNF009.pdf', 'BoletoNF009.pdf', 1, NULL),

    (2, 'NF010', '2023-04-05', '2023-05-05', '2023-05-10', 1600.00, 'DocumentoNF010.pdf', 'BoletoNF010.pdf', 2, 3),
    (3, 'NF011', '2023-04-15', '2023-05-15', NULL, 1400.00, 'DocumentoNF011.pdf', 'BoletoNF011.pdf', 3, 4),
    (1, 'NF012', '2023-04-20', NULL, NULL, 2300.00, 'DocumentoNF012.pdf', 'BoletoNF012.pdf', 4, NULL),

    (1, 'NF013', '2023-05-08', '2023-06-08', '2023-06-15', 2500.00, 'DocumentoNF013.pdf', 'BoletoNF013.pdf', 1, 2),
    (2, 'NF014', '2023-05-18', '2023-06-18', NULL, 1800.00, 'DocumentoNF014.pdf', 'BoletoNF014.pdf', 2, 3),
    (3, 'NF015', '2023-05-25', NULL, NULL, 2000.00, 'DocumentoNF015.pdf', 'BoletoNF015.pdf', 3, NULL),

    (3, 'NF016', '2023-06-10', '2023-07-10', '2023-07-15', 2100.00, 'DocumentoNF016.pdf', 'BoletoNF016.pdf', 4, 1),
    (1, 'NF017', '2023-06-20', '2023-07-20', NULL, 1700.00, 'DocumentoNF017.pdf', 'BoletoNF017.pdf', 1, 2),
    (2, 'NF018', '2023-06-28', NULL, NULL, 1900.00, 'DocumentoNF018.pdf', 'BoletoNF018.pdf', 2, NULL),

    (2, 'NF019', '2023-07-05', '2023-08-05', '2023-08-10', 1500.00, 'DocumentoNF019.pdf', 'BoletoNF019.pdf', 3, 4),
    (3, 'NF020', '2023-07-15', '2023-08-15', NULL, 1600.00, 'DocumentoNF020.pdf', 'BoletoNF020.pdf', 4, 1),
    (1, 'NF021', '2023-07-22', NULL, NULL, 2400.00, 'DocumentoNF021.pdf', 'BoletoNF021.pdf', 1, NULL),

    (1, 'NF022', '2023-08-10', '2023-09-10', '2023-09-15', 2200.00, 'DocumentoNF022.pdf', 'BoletoNF022.pdf', 2, 3),
    (2, 'NF023', '2023-08-18', '2023-09-18', NULL, 2000.00, 'DocumentoNF023.pdf', 'BoletoNF023.pdf', 3, 4),
    (3, 'NF024', '2023-08-25', NULL, NULL, 1800.00, 'DocumentoNF024.pdf', 'BoletoNF024.pdf', 4, NULL),

    (3, 'NF025', '2023-09-05', '2023-10-05', '2023-10-10', 1900.00, 'DocumentoNF025.pdf', 'BoletoNF025.pdf', 1, 2),
    (1, 'NF026', '2023-09-15', '2023-10-15', NULL, 1700.00, 'DocumentoNF026.pdf', 'BoletoNF026.pdf', 2, 3),
    (2, 'NF027', '2023-09-28', NULL, NULL, 2100.00, 'DocumentoNF027.pdf', 'BoletoNF027.pdf', 3, NULL),

    (2, 'NF028', '2023-10-08', '2023-11-08', '2023-11-15', 2000.00, 'DocumentoNF028.pdf', 'BoletoNF028.pdf', 4, 1),
    (3, 'NF029', '2023-10-18', '2023-11-18', NULL, 2200.00, 'DocumentoNF029.pdf', 'BoletoNF029.pdf', 1, 2),
    (1, 'NF030', '2023-10-25', NULL, NULL, 2300.00, 'DocumentoNF030.pdf', 'BoletoNF030.pdf', 2, NULL),

    (1, 'NF031', '2023-11-05', '2023-12-05', '2023-12-10', 2400.00, 'DocumentoNF031.pdf', 'BoletoNF031.pdf', 3, 4),
    (2, 'NF032', '2023-11-15', '2023-12-15', NULL, 1800.00, 'DocumentoNF032.pdf', 'BoletoNF032.pdf', 4, 1),
    (3, 'NF033', '2023-11-20', NULL, NULL, 1600.00, 'DocumentoNF033.pdf', 'BoletoNF033.pdf', 1, NULL),

    (3, 'NF034', '2023-12-08', '2024-01-08', '2024-01-15', 2000.00, 'DocumentoNF034.pdf', 'BoletoNF034.pdf', 2, 3),
    (1, 'NF035', '2023-12-18', '2024-01-18', NULL, 2200.00, 'DocumentoNF035.pdf', 'BoletoNF035.pdf', 3, 4),
    (2, 'NF036', '2023-12-25', NULL, NULL, 1700.00, 'DocumentoNF036.pdf', 'BoletoNF036.pdf', 4, NULL),

    (2, 'NF037', '2024-01-05', '2024-02-05', '2024-02-10', 1800.00, 'DocumentoNF037.pdf', 'BoletoNF037.pdf', 1, 2),
    (3, 'NF038', '2024-01-15', '2024-02-15', NULL, 1600.00, 'DocumentoNF038.pdf', 'BoletoNF038.pdf', 2, 3),
    (1, 'NF039', '2024-01-20', NULL, NULL, 1900.00, 'DocumentoNF039.pdf', 'BoletoNF039.pdf', 3, NULL),

    (1, 'NF040', '2024-02-08', '2024-03-08', '2024-03-15', 2100.00, 'DocumentoNF040.pdf', 'BoletoNF040.pdf', 4, 1),
    (2, 'NF041', '2024-02-18', '2024-03-18', NULL, 1700.00, 'DocumentoNF041.pdf', 'BoletoNF041.pdf', 1, 2),
    (3, 'NF042', '2024-02-25', NULL, NULL, 2200.00, 'DocumentoNF042.pdf', 'BoletoNF042.pdf', 2, NULL),
   
    (3, 'NF043', '2024-03-05', '2024-04-05', '2024-04-10', 2300.00, 'DocumentoNF043.pdf', 'BoletoNF043.pdf', 3, 4),
    (1, 'NF044', '2024-03-15', '2024-04-15', NULL, 1800.00, 'DocumentoNF044.pdf', 'BoletoNF044.pdf', 4, 1),
    (2, 'NF045', '2024-03-20', NULL, NULL, 2000.00, 'DocumentoNF045.pdf', 'BoletoNF045.pdf', 1, NULL),

    (2, 'NF046', '2024-04-08', '2024-05-08', '2024-05-15', 1900.00, 'DocumentoNF046.pdf', 'BoletoNF046.pdf', 2, 3),
    (3, 'NF047', '2024-04-18', '2024-05-18', NULL, 2100.00, 'DocumentoNF047.pdf', 'BoletoNF047.pdf', 3, 4),
    (1, 'NF048', '2024-04-25', NULL, NULL, 1600.00, 'DocumentoNF048.pdf', 'BoletoNF048.pdf', 4, NULL),

    (1, 'NF049', '2024-05-05', '2024-06-05', '2024-06-10', 2200.00, 'DocumentoNF049.pdf', 'BoletoNF049.pdf', 1, 2),
    (2, 'NF050', '2024-05-15', '2024-06-15', NULL, 1700.00, 'DocumentoNF050.pdf', 'BoletoNF050.pdf', 2, 3),
    (3, 'NF051', '2024-05-20', NULL, NULL, 1800.00, 'DocumentoNF051.pdf', 'BoletoNF051.pdf', 3, NULL),

    (3, 'NF052', '2024-06-08', '2024-07-08', '2024-07-15', 1900.00, 'DocumentoNF052.pdf', 'BoletoNF052.pdf', 4, 1),
    (1, 'NF053', '2024-06-18', '2024-07-18', NULL, 2000.00, 'DocumentoNF053.pdf', 'BoletoNF053.pdf', 1, 2),
    (2, 'NF054', '2024-06-25', NULL, NULL, 2100.00, 'DocumentoNF054.pdf', 'BoletoNF054.pdf', 2, NULL),

    (2, 'NF055', '2024-07-05', '2024-08-05', '2024-08-10', 2200.00, 'DocumentoNF055.pdf', 'BoletoNF055.pdf', 3, 4),
    (3, 'NF056', '2024-07-15', '2024-08-15', NULL, 1800.00, 'DocumentoNF056.pdf', 'BoletoNF056.pdf', 4, 1),
    (1, 'NF057', '2024-07-20', NULL, NULL, 1900.00, 'DocumentoNF057.pdf', 'BoletoNF057.pdf', 1, NULL),

    (1, 'NF058', '2024-08-08', '2024-09-08', '2024-09-15', 2000.00, 'DocumentoNF058.pdf', 'BoletoNF058.pdf', 2, 3),
    (2, 'NF059', '2024-08-18', '2024-09-18', NULL, 2100.00, 'DocumentoNF059.pdf', 'BoletoNF059.pdf', 3, 4),
    (3, 'NF060', '2024-08-25', NULL, NULL, 2200.00, 'DocumentoNF060.pdf', 'BoletoNF060.pdf', 4, NULL),

    (3, 'NF061', '2024-09-05', '2024-10-05', '2024-10-10', 1800.00, 'DocumentoNF061.pdf', 'BoletoNF061.pdf', 1, 2),
    (1, 'NF062', '2024-09-15', '2024-10-15', NULL, 1900.00, 'DocumentoNF062.pdf', 'BoletoNF062.pdf', 2, 3),
    (2, 'NF063', '2024-09-20', NULL, NULL, 2000.00, 'DocumentoNF063.pdf', 'BoletoNF063.pdf', 3, NULL),

    (2, 'NF064', '2024-10-08', '2024-11-08', '2024-11-15', 2100.00, 'DocumentoNF064.pdf', 'BoletoNF064.pdf', 4, 1),
    (3, 'NF065', '2024-10-18', '2024-11-18', NULL, 2200.00, 'DocumentoNF065.pdf', 'BoletoNF065.pdf', 1, 2),
    (1, 'NF066', '2024-10-25', NULL, NULL, 2300.00, 'DocumentoNF066.pdf', 'BoletoNF066.pdf', 2, NULL),

    (1, 'NF067', '2024-11-05', '2024-12-05', '2024-12-10', 1900.00, 'DocumentoNF067.pdf', 'BoletoNF067.pdf', 3, 4),
    (2, 'NF068', '2024-11-15', '2024-12-15', NULL, 2000.00, 'DocumentoNF068.pdf', 'BoletoNF068.pdf', 4, 1),
    (3, 'NF069', '2024-11-20', NULL, NULL, 2100.00, 'DocumentoNF069.pdf', 'BoletoNF069.pdf', 1, NULL),

    (3, 'NF070', '2024-12-08', '2025-01-08', '2025-01-15', 2200.00, 'DocumentoNF070.pdf', 'BoletoNF070.pdf', 2, 3),
    (1, 'NF071', '2024-12-18', '2025-01-18', NULL, 2300.00, 'DocumentoNF071.pdf', 'BoletoNF071.pdf', 3, 4),
    (2, 'NF072', '2024-12-25', NULL, NULL, 1800.00, 'DocumentoNF072.pdf', 'BoletoNF072.pdf', 4, NULL),

    (2, 'NF073', '2025-01-05', '2025-02-05', '2025-02-10', 2000.00, 'DocumentoNF073.pdf', 'BoletoNF073.pdf', 1, 2),
    (3, 'NF074', '2025-01-15', '2025-02-15', NULL, 2100.00, 'DocumentoNF074.pdf', 'BoletoNF074.pdf', 2, 3),
    (1, 'NF075', '2025-01-20', NULL, NULL, 2200.00, 'DocumentoNF075.pdf', 'BoletoNF075.pdf', 3, NULL),

    (1, 'NF076', '2025-02-08', '2025-03-08', '2025-03-15', 1800.00, 'DocumentoNF076.pdf', 'BoletoNF076.pdf', 4, 1),
    (2, 'NF077', '2025-02-18', '2025-03-18', NULL, 1900.00, 'DocumentoNF077.pdf', 'BoletoNF077.pdf', 1, 2),
    (3, 'NF078', '2025-02-25', NULL, NULL, 2000.00, 'DocumentoNF078.pdf', 'BoletoNF078.pdf', 2, NULL),

    (3, 'NF079', '2025-03-05', '2025-04-05', '2025-04-10', 2100.00, 'DocumentoNF079.pdf', 'BoletoNF079.pdf', 3, 4),
    (1, 'NF080', '2025-03-15', '2025-04-15', NULL, 2200.00, 'DocumentoNF080.pdf', 'BoletoNF080.pdf', 4, 1),
    (2, 'NF081', '2025-03-20', NULL, NULL, 1700.00, 'DocumentoNF081.pdf', 'BoletoNF081.pdf', 1, NULL),

    (2, 'NF082', '2025-04-08', '2025-05-08', '2025-05-15', 1900.00, 'DocumentoNF082.pdf', 'BoletoNF082.pdf', 2, 3),
    (3, 'NF083', '2025-04-18', '2025-05-18', NULL, 2000.00, 'DocumentoNF083.pdf', 'BoletoNF083.pdf', 3, 4),
    (1, 'NF084', '2025-04-25', NULL, NULL, 2100.00, 'DocumentoNF084.pdf', 'BoletoNF084.pdf', 4, NULL),

    (1, 'NF085', '2025-05-05', '2025-06-05', '2025-06-10', 1800.00, 'DocumentoNF085.pdf', 'BoletoNF085.pdf', 1, 2),
    (2, 'NF086', '2025-05-15', '2025-06-15', NULL, 1900.00, 'DocumentoNF086.pdf', 'BoletoNF086.pdf', 2, 3),
    (3, 'NF087', '2025-05-20', NULL, NULL, 2000.00, 'DocumentoNF087.pdf', 'BoletoNF087.pdf', 3, NULL),

    (3, 'NF088', '2025-06-08', '2025-07-08', '2025-07-15', 2100.00, 'DocumentoNF088.pdf', 'BoletoNF088.pdf', 4, 1),
    (1, 'NF089', '2025-06-18', '2025-07-18', NULL, 2200.00, 'DocumentoNF089.pdf', 'BoletoNF089.pdf', 1, 2),
    (2, 'NF090', '2025-06-25', NULL, NULL, 2300.00, 'DocumentoNF090.pdf', 'BoletoNF090.pdf', 2, NULL),
    
    (2, 'NF091', '2025-07-05', '2025-08-05', '2025-08-10', 2200.00, 'DocumentoNF091.pdf', 'BoletoNF091.pdf', 3, 4),
    (3, 'NF092', '2025-07-15', '2025-08-15', NULL, 1800.00, 'DocumentoNF092.pdf', 'BoletoNF092.pdf', 4, 1),
    (1, 'NF093', '2025-07-20', NULL, NULL, 1900.00, 'DocumentoNF093.pdf', 'BoletoNF093.pdf', 1, NULL),

    (1, 'NF094', '2025-08-08', '2025-09-08', '2025-09-15', 2000.00, 'DocumentoNF094.pdf', 'BoletoNF094.pdf', 2, 3),
    (2, 'NF095', '2025-08-18', '2025-09-18', NULL, 2100.00, 'DocumentoNF095.pdf', 'BoletoNF095.pdf', 3, 4),
    (3, 'NF096', '2025-08-25', NULL, NULL, 2200.00, 'DocumentoNF096.pdf', 'BoletoNF096.pdf', 4, NULL),

    (3, 'NF097', '2025-09-05', '2025-10-05', '2025-10-10', 1800.00, 'DocumentoNF097.pdf', 'BoletoNF097.pdf', 1, 2),
    (1, 'NF098', '2025-09-15', '2025-10-15', NULL, 1900.00, 'DocumentoNF098.pdf', 'BoletoNF098.pdf', 2, 3),
    (2, 'NF099', '2025-09-20', NULL, NULL, 2000.00, 'DocumentoNF099.pdf', 'BoletoNF099.pdf', 3, NULL),

    (2, 'NF100', '2025-10-08', '2025-11-08', '2025-11-15', 2100.00, 'DocumentoNF100.pdf', 'BoletoNF100.pdf', 4, 1),
    (3, 'NF101', '2025-10-18', '2025-11-18', NULL, 2200.00, 'DocumentoNF101.pdf', 'BoletoNF101.pdf', 1, 2),
    (1, 'NF102', '2025-10-25', NULL, NULL, 2300.00, 'DocumentoNF102.pdf', 'BoletoNF102.pdf', 2, NULL),

    (1, 'NF103', '2025-11-05', '2025-12-05', '2025-12-10', 1900.00, 'DocumentoNF103.pdf', 'BoletoNF103.pdf', 3, 4),
    (2, 'NF104', '2025-11-15', '2025-12-15', NULL, 2000.00, 'DocumentoNF104.pdf', 'BoletoNF104.pdf', 4, 1),
    (3, 'NF105', '2025-11-20', NULL, NULL, 2100.00, 'DocumentoNF105.pdf', 'BoletoNF105.pdf', 1, NULL),

    (3, 'NF106', '2025-12-08', '2026-01-08', '2026-01-15', 2200.00, 'DocumentoNF106.pdf', 'BoletoNF106.pdf', 2, 3),
    (1, 'NF107', '2025-12-18', '2026-01-18', NULL, 2300.00, 'DocumentoNF107.pdf', 'BoletoNF107.pdf', 3, 4),
    (2, 'NF108', '2025-12-25', NULL, NULL, 1800.00, 'DocumentoNF108.pdf', 'BoletoNF108.pdf', 4, NULL);