import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { Grid } from '../Grid';
import './App.css';
import { Customer } from '../Customer';

function AppUI() {

  return (
    <div className='App'>
        <Routes>    
            <Route path='/' element={<Grid />} />
            <Route path='/Customer' element={<Grid />} />
            <Route path='/Customer/:id' element={<Customer />} />
        </Routes>
    </div>
  );
}

export { AppUI };
