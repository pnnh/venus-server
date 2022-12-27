 
import React from 'react' 
import ReactDOM from 'react-dom' 
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import './index.scss' 
import './components/controls'
import { HomePage } from './pages/home'
 

const App = () => { 
  return <Router>
    <Routes>  
      <Route path="/" element={<HomePage/>}/> 
    </Routes>
  </Router>
}

const rootElement = document.getElementById('root')
if (rootElement) {
  ReactDOM.render(<App/>, rootElement) 
}