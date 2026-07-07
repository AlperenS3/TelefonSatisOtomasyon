CREATE TABLE Tbl_Sinavlar (
    SinavID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan benzersiz ID
    SinavAd VARCHAR(100) NOT NULL,          -- Sınavın Adı
    Kategori VARCHAR(50) NOT NULL,          -- Ders / Kategori bilgisi
    SinavNotu TINYINT NOT NULL,             -- Sınav Notu (0-100 arası yer kaplamaması için TINYINT)
    KayitTarihi DATETIME DEFAULT GETDATE()  -- Kaydın sisteme girildiği anki tarih
);