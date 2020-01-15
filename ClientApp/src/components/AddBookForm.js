import React, { useState } from 'react';
import axios from 'axios';


const AddBookForm = props => {

    const initialFormState = { id: null, bookName: '', authorName: '' }
    const [book, setBook] = useState(initialFormState);
    const url = "api/book/create";


    const handleInputChange = event => {
        const { name, value } = event.target
        setBook({ ...book, [name]: value})
        console.log("handleInput: ", book);
    }

    const handleSubmit = () => {
        //event.preventDefault();
        //data.id = books.length + 1;
        //data.bookName = book.bookName;
        //data.authorName = book.authorName;

        postData(url, book)
            .then(data => console.log(JSON.stringify(data))) // JSON-строка полученная после вызова `response.json()`
            .catch(error => console.error(error));
    }

    //async function addBookToDb(data) {
    //    const res = await axios.post('https://localhost:44375/api/book/create', data);
    //        //.then(response => console.log(response))
    //    //.catch((err) => console.log(err))
    //    return res.data;
    //}


    // Пример отправки POST запроса:

    //postData('http://example.com/answer', { answer: 42 })
    //    .then(data => console.log(JSON.stringify(data))) // JSON-строка полученная после вызова `response.json()`
    //    .catch(error => console.error(error));

    function postData(url = '', data = {}) {
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
        console.log("fetch data: ", data);
    }
    //setBook(initialFormState)

    return (
        <form
            onSubmit={event => {
                event.preventDefault()
                if (!book.bookName || !book.authorName) return
                //props.addBook(book);
                handleSubmit();
                
            }}>
            <label>Book name</label>
            <input type="text" name="bookName" value={book.bookName} onChange={handleInputChange} />
            <label>Author name</label>
            <input type="text" name="authorName" value={book.authorName} onChange={handleInputChange} />
            <button>Add new book</button>
        </form>
    )
}

export default AddBookForm