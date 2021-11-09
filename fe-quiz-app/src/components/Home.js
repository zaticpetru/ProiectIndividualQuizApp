import React, { useState } from 'react';
import ErrorBoundary from './ErrorBoundary';
import Counter from './Counter';

function Home() {
    return (
        <>
            <div>
                <h1>Home page</h1>
            </div>
            <header className="App-header">
                    <ErrorBoundary>
                        <Counter />
                    </ErrorBoundary>
            </header>
        </>
    );
}

export default Home;