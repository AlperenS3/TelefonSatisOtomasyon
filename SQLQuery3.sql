-- Eğer varsa eski tabloyu uçuruyoruz
DROP TABLE Kasa;
GO

-- Profesyonel Kasa Tablosu
CREATE TABLE Kasa (
    KasaID INT PRIMARY KEY IDENTITY(1,1),
    IslemTipi NVARCHAR(50), -- 'Satış', 'Teknik Servis', 'Gider'
    Tutar DECIMAL(18,2),
    Aciklama NVARCHAR(500),
    Tarih DATETIME DEFAULT GETDATE()
);
GO