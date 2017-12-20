-- *************************************************************************************************
-- This script creates all of the database objects (tables, constraints, etc) for the database
-- *************************************************************************************************

DROP TABLE homes_users_chores
DROP TABLE users
DROP TABLE homes
DROP TABLE chores

BEGIN;

CREATE TABLE homes (
	homeID INT IDENTITY,
	homename VARCHAR(100) not null

	CONSTRAINT pk_homes PRIMARY KEY (homeID)
);

CREATE TABLE users (
	userID INT IDENTITY,
	username VARCHAR(100) not null,
	email VARCHAR (100) not null,
	homename VARCHAR (100) not null,
	password VARCHAR(100) not null,
	salt VARCHAR(100) not null,

	CONSTRAINT pk_users PRIMARY KEY (userID),
);

CREATE TABLE chores (
	choreID INT IDENTITY,
	chorename VARCHAR (100) not null,
	frequency VARCHAR (100),
	description VARCHAR (255),
	homeID INT not null,

	CONSTRAINT pk_chores PRIMARY KEY (choreID)
);

CREATE TABLE homes_users_chores (
	pk_homes_users_chores INT not null,
	homeID INT not null,
	homename VARCHAR(100) not null,
	userID INT not null,
	username VARCHAR(100) not null,
	choreID INT not null,
	chorename VARCHAR(100) not null,
	dateCompleted DATE,
	comments VARCHAR(255),

	CONSTRAINT pk_homes_users_chores PRIMARY KEY (homeID,userID,choreID),
	CONSTRAINT fk_homeID FOREIGN KEY (homeID) REFERENCES homes (homeID),
	CONSTRAINT fk_userID FOREIGN KEY (userID) REFERENCES users (userID),
	CONSTRAINT fk_choreID FOREIGN KEY (choreID) REFERENCES chores (choreID)
);

COMMIT;
