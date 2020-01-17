import React from "react";

const BookTable = (props) => (
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Author name</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            {props.books.map(book => (

                <tr key={book.id}>
                    <td>{book.bookName}</td>
                    <td>{book.authorName}</td>
                <td>
                        <button className="button muted-button">Edit</button>
                        <button className="button muted-button" onClick={() => props.deleteBook(book.id)}>Delete</button>
                </td>
                </tr>
            ))}
        </tbody>
    </table>
)

export default BookTable;
