CREATE TABLE TblStajyerler (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    StajyerNo VARCHAR(20) NOT NULL UNIQUE,
    Adi NVARCHAR(50) NOT NULL,
    Soyadi NVARCHAR(50) NOT NULL,
    Cinsiyet VARCHAR(5) NOT NULL, -- 'Erkek' veya 'Kadın' değerlerini tutar
    DogumTarihi DATE NOT NULL,
    Bolum NVARCHAR(100) NOT NULL, -- 'Yazılım Geliştirme', 'Tasarım' vb.
    SigortaDurumu VARCHAR(3) NOT NULL -- 'Var' veya 'Yok' değerlerini tutar
);