import { Routes, Route } from 'react-router-dom'
import './App.css'
import Authentication from './Pages/Authentication'
import PrivateRoute from './Components/PrivateRoute'
import Main from './Components/Main'

function App() {
  return (
    <>
      <Routes>
        <Route path='/login' element={<Authentication />} />
        <Route element={<PrivateRoute />}>
          <Route path='/' element={<Main />} />
        </Route>
      </Routes>
    </>
  )
}

export default App
