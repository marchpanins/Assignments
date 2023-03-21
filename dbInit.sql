CREATE TABLE users (
  id INT NOT NULL AUTO_INCREMENT,
  username VARCHAR(50) NOT NULL,
  password VARCHAR(255) NOT NULL,
  email VARCHAR(100) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE assignments (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  urgency_level varchar(255) NOT NULL,
  due_date DATE NOT NULL,
  user_id INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (user_id) REFERENCES users(id)
);


INSERT INTO users (username, password, email) VALUES ('john', 'password', 'john_doe@example.com');

INSERT INTO users (username, password, email) VALUES ('jane', 'password', 'jane_smith@example.com');

INSERT INTO users (username, password, email) VALUES ('bob', 'password', 'bob_smith@example.com');