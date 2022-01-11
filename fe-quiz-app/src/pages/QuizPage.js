import React from 'react';
import Quiz from "../components/Quiz"
import { useNavigate, Link } from "react-router-dom";


const QuizPage = () => {

    const dummyQuizzes = 
        [
            {
                title: 'First Quiz',
                id: '1',
            },
            {
                title: 'Second Quiz',
                id: '2'
            }, 
            {
                title: 'Third Quiz',
                id: '3',
            },
            {
                title: 'Fourth Quiz',
                id: '4'
            }, 
            {
                title: 'Fifth Quiz',
                id: '5'
            }, 
            {
                title: 'Sixth Quiz',
                id: '6'
            }, 

        ]

    return (
        <div className='grid grid-cols-4 gap-4'>
            {dummyQuizzes.map((quiz, index) => {
                return (
                    <Link to={quiz.id}>
                        <div className='border border-pink-500' key={index}>
                            <h1> {quiz.title} </h1>
                        </div>
                    </Link>
                )
            })}
        </div>
    )
}

export default QuizPage