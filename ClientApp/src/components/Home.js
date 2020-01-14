import React, { useState, useEffect } from 'react';
import BookTable from './BookTable';

const Home = () => {
    const bookData = [
        { id: 0, bookName: null, authorName: null }];
    const [hasError, setErrors] = useState(false);
    const [books, setBooks] = useState(bookData);



    useEffect(() => {
        async function fetchData() {
            const res = await fetch("https://localhost:44375/api/books");
            res.json()
                .then(res => setBooks(res))
                .catch(err => setErrors(err));
        }

        fetchData();
    });

    return (
        
        <div>
            <BookTable books={books}/>
            <span>{JSON.stringify(books)}</span>
            <hr />
            <span>Has error: {JSON.stringify(hasError)}</span>
        </div>
        )
}

export default Home;