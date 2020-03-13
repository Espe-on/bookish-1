CREATE DATABASE IF NOT EXISTS `bookish`;
USE bookish;

CREATE TABLE IF NOT EXISTS `member` (
    id int primary key auto_increment,
    first_name varchar(128) NOT NULL,
    last_name varchar(128) NOT NULL
);