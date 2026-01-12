
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

-- Table DetailsVente
CREATE TABLE DetailsVente (
    IdDetailVente INT IDENTITY(1,1) PRIMARY KEY,
    IdVente INT NOT NULL,
    IdProduit INT NOT NULL,
    Qtte INT NOT NULL,
    PU DECIMAL(10,2) NOT NULL,
    Ptt AS (Qtte * PU) PERSISTED,
    CONSTRAINT FK_DetailsVente_Vente
        FOREIGN KEY (IdVente) REFERENCES Vente(IdVente),
    CONSTRAINT FK_DetailsVente_Produit
        FOREIGN KEY (IdProduit) REFERENCES Produits(IdProduit)
);


