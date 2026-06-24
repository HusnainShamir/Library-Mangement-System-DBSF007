USE Library_Managment_System;

DELIMITER //

CREATE PROCEDURE IssueBook(
    IN pMemberID INT,
    IN pCopyID INT
)
BEGIN

    INSERT INTO Issues(
        MemberID,
        CopyID,
        IssueDate,
        DueDate
    )
    VALUES(
        pMemberID,
        pCopyID,
        CURDATE(),
        DATE_ADD(CURDATE(),INTERVAL 14 DAY)
    );

    UPDATE BookCopies
    SET Status='Issued'
    WHERE CopyID=pCopyID;

END //

DELIMITER ;