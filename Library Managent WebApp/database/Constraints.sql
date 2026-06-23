USE Library_Managment_System;
ALTER TABLE Books
ADD CONSTRAINT chk_year
CHECK (PublishYear >= 1900);

ALTER TABLE Fines
ADD CONSTRAINT chk_amount
CHECK (Amount >= 0);