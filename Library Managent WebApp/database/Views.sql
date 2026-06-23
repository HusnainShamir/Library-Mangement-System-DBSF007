USE Library_Managment_System;
CREATE VIEW AvailableBooks AS
SELECT
    b.BookID,
    b.Title,
    bc.CopyID
FROM Books b
JOIN BookCopies bc
ON b.BookID = bc.BookID
WHERE bc.Status = 'Available';