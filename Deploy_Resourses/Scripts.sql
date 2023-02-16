CREATE DATABASE dbCarInsurancePolicy
GO

CREATE TABLE CarInsurancePolicy
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    PolicyNumber NVARCHAR(10) not null,
    ClientName NVARCHAR(200) not null,
    ClientIdentification NVARCHAR(30) not null,
    ClientBirthdate DATETIME not null,
    CoveragePolicy NVARCHAR(600) not null,
    MaxValue DECIMAL not null,
    PolicyName NVARCHAR(50) not null,
    City NVARCHAR(100) not null,
    Direction NVARCHAR(100) not null,
    LicensePlate NVARCHAR(10) not null,
    ModelCar int not null,
    HaveInspection BIT not null,
    DateCreation DATETIME not null
)

GO;

CREATE OR ALTER PROCEDURE Sp_Insert_CarInsurancePolicy
    @PolicyNumber NVARCHAR(10),
    @ClientName NVARCHAR(200),
    @ClientIdentification NVARCHAR(30),
    @ClientBirthdate DATETIME,
    @CoveragePolicy NVARCHAR(600),
    @MaxValue DECIMAL,
    @PolicyName NVARCHAR(50),
    @City NVARCHAR(100),
    @Direction NVARCHAR(100),
    @LicensePlate NVARCHAR(10),
    @ModelCar int,
    @HaveInspection BIT,
    @DateCreation DATETIME,
     @Id UNIQUEIDENTIFIER OUTPUT
    AS
    BEGIN
        SET @Id = NEWID();
        INSERT INTO CarInsurancePolicy 
                (   Id,
                    PolicyNumber,
                    ClientName,
                    ClientIdentification,
                    ClientBirthdate,
                    CoveragePolicy,
                    MaxValue,
                    PolicyName,
                    City,
                    Direction,
                    LicensePlate,
                    ModelCar,
                    HaveInspection,
                    DateCreation
                ) 
                VALUES 
                (
                    @Id,
                    @PolicyNumber,
                    @ClientName,
                    @ClientIdentification,
                    @ClientBirthdate,
                    @CoveragePolicy,
                    @MaxValue,
                    @PolicyName,
                    @City,
                    @Direction,
                    @LicensePlate,
                    @ModelCar,
                    @HaveInspection,
                    @DateCreation
                )
    END
    GO
