import { Routes, Route } from 'react-router-dom'
import './App.css'
import Authentication from './Pages/Authentication'

function App() {
  return (
    <>
      <Routes>
        <Route Component={Authentication} path='/login'>

        </Route>
      </Routes>
    </>
  )
}

export default App
