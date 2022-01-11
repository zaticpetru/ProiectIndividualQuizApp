import React from 'react';

const Button = (props) => {
    return (
        <button className="w-full flex justify-center py-1 px-4 border border-transparent font-medium rounded-md text-pink-50 bg-pink-500 hover:bg-pink-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-pink-500">
            {props.children}
        </button>
    )
}

export default Button