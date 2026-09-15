# Address Book Application

A console-based C# Address Book application for managing contacts across multiple address books.

## Features

* Add, edit, and delete contacts
* Validate contact details
* Prevent duplicate contacts
* Display all contacts
* Count contacts across address books
* Search contacts by city or state
* View contacts grouped by city or state
* Count contacts by city or state
* Sort contacts by name, city, state, or zip

## Project Structure

```text
AddressBookApp
├── src
│   └── AddressBookApp
│       ├── Models
│       ├── Services
│       ├── Validation
│       └── Exceptions
├── tests
│   └── AddressBookTests
└── AddressBookApp.slnx
```

## Technologies

* C#
* .NET
* NUnit

## C# / LINQ Concepts Used

* **Any()** – Check for duplicate contacts
* **FirstOrDefault()** – Find a contact for editing or deleting
* **SelectMany()** – Combine contacts from multiple address books
* **Where()** – Search contacts by city or state
* **GroupBy()** – Group contacts by city or state
* **Select()** – Calculate counts by city or state
* **Sum()** – Calculate total contacts across address books
* **OrderBy()** – Sort contacts by city, state, or zip
* **ThenBy()** – Sort contacts by first name and then last name
* **IReadOnlyList<T>** – Expose contacts without allowing direct modification of the internal list
* **StringComparison.OrdinalIgnoreCase** – Perform case-insensitive comparisons

## Testing

Unit tests are written using **NUnit** to test contact validation and application functionality.

## Git Workflow

Each use case was developed in a separate feature branch and merged into the main branch.
