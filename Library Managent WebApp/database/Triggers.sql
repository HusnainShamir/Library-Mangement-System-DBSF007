USE Library_Managment_System;
DELIMITER //

CREATE TRIGGER trg_book_issued
AFTER INSERT ON Issues
FOR EACH ROW
BEGIN
    UPDATE BookCopies
    SET Status='Issued'
    WHERE CopyID=NEW.CopyID;

END //

DELIMITER ;