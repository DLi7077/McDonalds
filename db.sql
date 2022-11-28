USE McDonalds;

create table food (
	id int PRIMARY KEY AUTO_INCREMENT,
	name varchar(50) NOT NULL,
    price float NOT NULL,
    calories int,
    protein int,
    carbs int,
    sodium int,
    sugar int,
    fat int,
    CONSTRAINT name UNIQUE (name)
);

create table combo (
	id int PRIMARY KEY AUTO_INCREMENT,
    name varchar(100) NOT NULL UNIQUE,
    price float NOT NULL
);

create table comboItem (
	Id int PRIMARY KEY AUTO_INCREMENT, 
	foodId int,
    comboId int,
	FOREIGN KEY (foodId) REFERENCES food(id),
    FOREIGN KEY (comboId) REFERENCES combo(id)
);

