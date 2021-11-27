import React, { useContext } from 'react';
import AuthContext from '../context/authContext/AuthContext';
import { Link } from "react-router-dom";


function Home() {

    return (
        <main className="mt-5 mx-10">
            <div className="flex flex-col justify-around items-center space-y-6 border border-pink-500 p-20 my-auto">
                <h1 className="text-4xl"> Welcome to quizz app </h1>
                <h3> Please sign in to continue </h3>
                <Link to="/signin">
                    <button className="w-full flex justify-center py-2 px-4 border border-transparent font-medium rounded-md text-pink-50 bg-pink-500 hover:bg-pink-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-pink-500">
                        Sign in 
                    </button>
                </Link>
            </div>
        </main>
    );
}

export default Home;