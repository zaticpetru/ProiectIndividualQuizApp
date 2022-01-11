import React from 'react';
import { Link } from "react-router-dom";
import Button from '../components/Button';


function Home() {

    return (
        <main className="mt-5 mx-10">
            <div className="flex flex-col justify-around items-center space-y-6 border border-pink-500 p-20 my-auto">
                <h1 className="text-4xl"> Welcome to quizz app </h1>
                <Link to="/quiz">
                    <Button>
                        Go to quiz page
                    </Button>
                </Link>
                <h3> Please sign in to continue </h3>
                <Link to="/signin">
                    <Button>
                        Sign In
                    </Button>
                </Link>
            </div>
        </main>
    );
}

export default Home;