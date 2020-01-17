import React, { useState, useEffect } from 'react';
import BookTable from './BookTable';
import AddBookForm from './AddBookForm';
import {BookApi} from '../api/books';

const Home = () => {
    const bookData = [
        { bookId: 0, bookName: null, authorName: null }];
    const [hasError, setErrors] = useState(false);
    const [books, setBooks] = useState(bookData);

    const addBook = book => {
        //book.bookId = books.length + 1
        //setBooks([...books, book])

        addBook("api/book/create", book)
            .then(data => console.log(JSON.stringify(data))) // JSON-строка полученная после вызова `response.json()`
            .catch(error => console.error(error));

        function addBook(url = '', data = {}) {
            // Значения по умолчанию обозначены знаком *
            return fetch(url, {
                method: 'POST', // *GET, POST, PUT, DELETE, etc.
                mode: 'cors', // no-cors, cors, *same-origin
                cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
                credentials: 'same-origin', // include, *same-origin, omit
                headers: {
                    'Content-Type': 'application/json',
                    // 'Content-Type': 'application/x-www-form-urlencoded',
                },
                redirect: 'follow', // manual, *follow, error
                referrer: 'no-referrer', // no-referrer, *client
                body: JSON.stringify(data), // тип данных в body должен соответвовать значению заголовка "Content-Type"
            })
                .then(response => response.json()); // парсит JSON ответ в Javascript объект
        }
        console.log("book has been add");
    }

    const delBook = id => {
        deleteBook(id)
            .then(response => console.log(response.json()));

        function deleteBook(id) {
            return fetch(`api/book/delete/${id}`, {
                method: 'POST'
            })
            
        }

        console.log("book has been del");
    }
    

    useEffect(() => {

        async function getBooks() {
            const res = await fetch("api/books");
            res.json()
                .then(res => setBooks(res))
                .catch(err => setErrors(err));
            console.log(res);
        }
    
        getBooks();
    }, []);

    return (
        
        <div>
            <AddBookForm addBook={addBook}/>
            <hr />
            <BookTable books={books} deleteBook={delBook}/>
            <hr />
            
            <span>{console.log(JSON.stringify(books))}</span>
            <span>{console.log(" Has error: ", JSON.stringify(hasError))}</span>
        </div>
        )
}

export default Home;