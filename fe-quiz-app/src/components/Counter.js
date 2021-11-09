import React, { useState } from 'react';
import './Counter.css';

function Counter() {
    const [count, setCount] = useState(0);


    if(count > 5) throw new Error('Counter crushed');
    
    return (
      <div className="counter">
        <p>You clicked {count} times</p>
        <button onClick={() => setCount(count + 1)}>
          Click me
        </button>
      </div>
    );
}

export default Counter;