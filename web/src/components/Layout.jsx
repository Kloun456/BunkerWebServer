import style from "./Layout.module.css"
import { LobbyWindow } from "./windows/LobbyWindow.jsx"
import { StartWindow } from "./windows/StartWindow.jsx"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

export const Layout = () =>{
    return(
    <div className={style.layout}>
        <Router>
            <Routes>
                <Route path="/" element={<StartWindow/>} />
                <Route path="/lobby" element={<LobbyWindow/>} />
            </Routes>
        </Router>
    </div>)
}