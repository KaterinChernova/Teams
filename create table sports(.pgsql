create table sports(
    id serial PRIMARY KEY,
    name varchar(200),
    description varchar(1000)
);

create table teams(
    id serial PRIMARY KEY,
    name varchar(150),
    age INTEGER,
    raiting numeric(4),
    sport_id integer REFERENCES sports(id)
);

create table cretificates(
    id serial PRIMARY KEY,
    name varchar(200),
    location varchar(300),
    type integer
);

create table team_certificates(
    id serial PRIMARY KEY,
    team_id integer REFERENCES teams(id),
    cert_id integer REFERENCES cretificates(id)
);