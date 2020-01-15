import React, { useState, useEffect } from 'react';
import BookTable from './BookTable';
import AddBookForm from './AddBookForm';
import axios from 'axios';

const Home = () => {
    const bookData = [
        { bookId: 0, bookName: null, authorName: null }];
    const [hasError, setErrors] = useState(false);
    const [books, setBooks] = useState(bookData);

    const addBook = book => {
        book.bookId = books.length + 1
        setBooks([...books, book])
    }

    useEffect(() => {
        //async function fetchData() {
        //    const res = await axios.get('https://localhost:44375/api/books');
        //    res.json()
        //        .then(res => setBooks(res))
        //        .catch(err => setErrors(err));
        //            console.log(res);
        //}

        async function fetchData() {
            const res = await fetch("api/books");
            res.json()
                .then(res => setBooks(res))
                .catch(err => setErrors(err));
        console.log(res);
        }
        fetchData();
    });

    return (
        
        <div>
            <AddBookForm addBook={addBook} books={books}/>
            <hr />
            <BookTable books={books} />
            <hr />
            
            <span>{console.log(JSON.stringify(books))}</span>
            <span>{console.log(" Has error: ", JSON.stringify(hasError))}</span>
        </div>
        )
}

export default Home;