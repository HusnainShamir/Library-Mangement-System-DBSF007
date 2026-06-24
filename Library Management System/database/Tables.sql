CREATE DATABASE Library_Managment_System;
USE Library_Managment_System;
CREATE TABLE Roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE
);
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    RoleID INT NOT NULL,
    
    FOREIGN KEY (RoleID)
    REFERENCES Roles(RoleID)
);
CREATE TABLE Members (
    MemberID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT NOT NULL UNIQUE,

    FullName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Address TEXT,
    RegistrationDate DATE NOT NULL,

    FOREIGN KEY (UserID)
    REFERENCES Users(UserID)
);
CREATE TABLE Authors (
    AuthorID INT AUTO_INCREMENT PRIMARY KEY,
    AuthorName VARCHAR(100) NOT NULL
);
CREATE TABLE Publishers (
    PublisherID INT AUTO_INCREMENT PRIMARY KEY,
    PublisherName VARCHAR(100) NOT NULL
);
CREATE TABLE Categories (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL UNIQUE
);
CREATE TABLE Books (
    BookID INT AUTO_INCREMENT PRIMARY KEY,

    Title VARCHAR(200) NOT NULL,
    ISBN VARCHAR(20) UNIQUE,

    CategoryID INT,
    PublisherID INT,

    PublishYear INT,

    FOREIGN KEY (CategoryID)
    REFERENCES Categories(CategoryID),

    FOREIGN KEY (PublisherID)
    REFERENCES Publishers(PublisherID)
);
CREATE TABLE BookAuthors (
    BookID INT,
    AuthorID INT,

    PRIMARY KEY (BookID, AuthorID),

    FOREIGN KEY (BookID)
    REFERENCES Books(BookID),

    FOREIGN KEY (AuthorID)
    REFERENCES Authors(AuthorID)
);
CREATE TABLE BookCopies (

    CopyID INT AUTO_INCREMENT PRIMARY KEY,

    BookID INT NOT NULL,

    Barcode VARCHAR(50) UNIQUE,

    Status ENUM(
        'Available',
        'Issued',
        'Reserved',
        'Lost'
    ) DEFAULT 'Available',

    FOREIGN KEY (BookID)
    REFERENCES Books(BookID)
);
CREATE TABLE Issues (

    IssueID INT AUTO_INCREMENT PRIMARY KEY,

    MemberID INT NOT NULL,
    CopyID INT NOT NULL,

    IssueDate DATE NOT NULL,
    DueDate DATE NOT NULL,

    ReturnDate DATE,

    FOREIGN KEY (MemberID)
    REFERENCES Members(MemberID),

    FOREIGN KEY (CopyID)
    REFERENCES BookCopies(CopyID)
);
CREATE TABLE Reservations (

    ReservationID INT AUTO_INCREMENT PRIMARY KEY,

    MemberID INT NOT NULL,
    BookID INT NOT NULL,

    ReservationDate DATE NOT NULL,

    Status ENUM(
        'Pending',
        'Completed',
        'Cancelled'
    ) DEFAULT 'Pending',

    FOREIGN KEY (MemberID)
    REFERENCES Members(MemberID),

    FOREIGN KEY (BookID)
    REFERENCES Books(BookID)
);
CREATE TABLE Fines (

    FineID INT AUTO_INCREMENT PRIMARY KEY,

    IssueID INT NOT NULL UNIQUE,

    Amount DECIMAL(10,2) NOT NULL,

    Paid BOOLEAN DEFAULT FALSE,

    FOREIGN KEY (IssueID)
    REFERENCES Issues(IssueID)
);
CREATE TABLE Payments (

    PaymentID INT AUTO_INCREMENT PRIMARY KEY,

    FineID INT NOT NULL,

    Amount DECIMAL(10,2) NOT NULL,

    PaymentDate DATE NOT NULL,

    FOREIGN KEY (FineID)
    REFERENCES Fines(FineID)
);
CREATE TABLE Notifications (

    NotificationID INT AUTO_INCREMENT PRIMARY KEY,

    MemberID INT NOT NULL,

    Message TEXT NOT NULL,

    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (MemberID)
    REFERENCES Members(MemberID)
);
CREATE TABLE ErrorLogs (

    LogID INT AUTO_INCREMENT PRIMARY KEY,

    ErrorMessage TEXT,

    LogTime DATETIME DEFAULT CURRENT_TIMESTAMP
);