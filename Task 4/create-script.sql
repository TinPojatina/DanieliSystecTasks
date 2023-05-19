
CREATE TYPE member_status AS ENUM ('active', 'frequent', 'inactive');
CREATE TYPE movie_status AS ENUM ('borrowed', 'not borrowed');


CREATE TABLE Members (
    userId SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(200) NOT NULL,
    phoneNumber VARCHAR(20) NOT NULL,
    dateOfJoin DATE NOT NULL,
    status member_status NOT NULL DEFAULT 'active'
);

CREATE TABLE Movies (
    movieId SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    genre VARCHAR(50) NOT NULL,
    yearOfRelease INT NOT NULL,
    status movie_status NOT NULL DEFAULT 'not borrowed'
);

CREATE TABLE Rentals (
    rentalId SERIAL PRIMARY KEY,
    userId INT,
    movieId INT,
    dateReserved DATE NOT NULL,
    dateValidUntil DATE NOT NULL,
    FOREIGN KEY (userId) REFERENCES Members (userId),
    FOREIGN KEY (movieId) REFERENCES Movies (movieId)
);

-- Populate the Members table
INSERT INTO Members (name, address, phoneNumber, dateOfJoin, status)
VALUES 
('John Doe', '123 Main St, New York, NY', '212-555-1234', '2022-01-01', 'active'),
('Jane Smith', '456 Park Ave, New York, NY', '212-555-5678', '2022-03-15', 'inactive'),
('Alice Johnson', '789 Broadway, New York, NY', '212-555-9012', '2023-02-20', 'active'),
('Bob Williams', '321 East St, New York, NY', '212-555-3456', '2021-06-01', 'active'),
('Charlie Brown', '654 West St, New York, NY', '212-555-7890', '2022-07-10', 'inactive');

-- Populate the Movies table
INSERT INTO Movies (name, genre, yearOfRelease, status)
VALUES 
('Interstellar', 'Sci-Fi', 2014, 'not borrowed'),
('The Godfather', 'Drama', 1972, 'borrowed'),
('The Dark Knight', 'Action', 2008, 'not borrowed'),
('Inception', 'Sci-Fi', 2010, 'borrowed'),
('The Matrix', 'Sci-Fi', 1999, 'not borrowed');

-- Populate the Rentals table
INSERT INTO Rentals (userId, movieId, dateReserved, dateValidUntil)
VALUES 
(1, 2, '2023-05-10', '2023-05-17'),
(3, 4, '2023-05-01', '2023-05-08'),
(1, 3, '2023-05-18', '2023-05-25'),
(2, 1, '2023-04-25', '2023-05-02'),
(4, 5, '2023-05-15', '2023-05-22');
