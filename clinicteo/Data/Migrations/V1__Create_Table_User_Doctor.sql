CREATE TABLE "user-doctor" (
    "id" SERIAL PRIMARY KEY,
    "first-name" VARCHAR(255) NOT NULL,
    "last-name" VARCHAR(255) NOT NULL,
    "email" VARCHAR(255) NOT NULL,
    "crm" VARCHAR(255) NOT NULL,
    "password" VARCHAR(255) NOT NULL,
    "create-at" DATE,
    "update-at" DATE,
    "roles" VARCHAR(255)[] NOT NULL
);