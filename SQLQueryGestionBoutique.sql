
CREATE DATABASE GestionBoutique;

-- Table Produits
CREATE TABLE Produits (
    IdProduit INT IDENTITY(1,1) PRIMARY KEY,
    Description VARCHAR(255) NOT NULL,
    Prix_unitaire_de_vente DECIMAL(10,2) NOT NULL
);

-- Table Clients
CREATE TABLE Clients (
    IdClient INT IDENTITY(1,1) PRIMARY KEY,
    Nom VARCHAR(150) NOT NULL,
    Adresse VARCHAR(255)
);

-- Table Vente
CREATE TABLE Vente (
    IdVente INT IDENTITY(1,1) PRIMARY KEY,
    IdClient INT NOT NULL,
    DateVente DATETIME NOT NULL,
    CONSTRAINT FK_Vente_Client
        FOREIGN KEY (IdClient) REFERENCES Clients(IdClient)
);


--Procedure stockant une vente avec plusieurs produits

CREATE PROCEDURE InsererVenteAvecPlusieursProduits
(
    @IdClient INT,
    @Produits VARCHAR(MAX)
)
AS
BEGIN
    DECLARE @IdVente INT;

    -- 1️⃣ Créer la vente
    INSERT INTO Vente (IdClient, DateVente)
    VALUES (@IdClient, GETDATE());

    SET @IdVente = SCOPE_IDENTITY();

    -- 2️⃣ Découper la liste des produits
    DECLARE @Produit VARCHAR(100);

    WHILE LEN(@Produits) > 0
    BEGIN
        IF CHARINDEX(';', @Produits) > 0
        BEGIN
            SET @Produit = LEFT(@Produits, CHARINDEX(';', @Produits) - 1);
            SET @Produits = SUBSTRING(@Produits, CHARINDEX(';', @Produits) + 1, LEN(@Produits));
        END
        ELSE
        BEGIN
            SET @Produit = @Produits;
            SET @Produits = '';
        END

        DECLARE @IdProduit INT;
        DECLARE @Qtte INT;
        DECLARE @PU DECIMAL(10,2);

        -- Découper IdProduit, Qtte, PU
        SET @IdProduit = PARSENAME(REPLACE(@Produit, ',', '.'), 3);
        SET @Qtte      = PARSENAME(REPLACE(@Produit, ',', '.'), 2);
        SET @PU        = PARSENAME(REPLACE(@Produit, ',', '.'), 1);

        -- 3️⃣ Insérer le détail
        INSERT INTO DetailsVente (IdVente, IdProduit, Qtte, PU)
        VALUES (@IdVente, @IdProduit, @Qtte, @PU);
    END
END;
GO



--Pour tester l'appel du procedure
  EXEC InsererVenteAvecPlusieursProduits
    2,
    '1,2,10;3,1,25;2,4,8';
