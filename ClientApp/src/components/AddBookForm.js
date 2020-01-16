import React, { useState } from 'react';
import axios from 'axios';


const AddBookForm = props => {

    const initialFormState = { id: null, bookName: '', authorName: '' }
    const [book, setBook] = useState(initialFormState);


    const handleInputChange = event => {
        const { name, value } = event.target
        setBook({ ...book, [name]: value })
        console.log("handleInput: ", book);
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        if (!book.bookName || !book.authorName) return
        props.addBook(book);
        setBook(initialFormState);
    }

    return (
        <form onSubmit={handleSubmit}>
            <label>Book name</label>
            <input type="text" name="bookName" value={book.bookName} onChange={handleInputChange} />
            <label>Author name</label>
            <input type="text" name="authorName" value={book.authorName} onChange={handleInputChange} />
            <button>Add new book</button>
        </form>
    )
}

export default AddBookForm