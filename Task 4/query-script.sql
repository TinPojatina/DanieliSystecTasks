-- a. ispisati sve filmove žanra „Akcija“ (SELECT)
SELECT * FROM Movies WHERE genre = 'Action';

-- b. ispisati sve posuđene filmove žanra „Akcija“ (SELECT)
SELECT * FROM Movies WHERE genre = 'Action' AND status = 'borrowed';

-- c. ažurirati žanr svih filmova starijih od 1980. na žanr „Klasika“ (UPDATE)
UPDATE Movies SET genre = 'Classic' WHERE yearOfRelease < 1980;

-- d. evidentirati povijest posudbe X na dan vraćanja filma u tabelu Povijest Posudbi (INSERT+SELECT) te obrisati posudbu X iz tabele Posudbe (DELETE)
INSERT INTO RentalHistory (rentalId, userId, movieId, dateReserved, dateReturned)
SELECT rentalId, userId, movieId, dateReserved, CURRENT_DATE FROM Rentals WHERE rentalId = X;
DELETE FROM Rentals WHERE rentalId = X;

-- e. ažurirati status svih članova na status „Frequent“ koji imaju arhivirano više od 50 posudbi (UPDATE)

UPDATE Members 
SET status = 'Frequent' 
WHERE userId IN (
    SELECT userId 
    FROM RentalHistory 
    GROUP BY userId 
    HAVING COUNT(rentalId) > 50
);
