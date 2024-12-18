import { useNavigate } from 'react-router-dom'
import style from './StartWindow.module.css'
import userStore from '../../stores/UserStore';
import { useEffect } from "react";

export const LobbyWindow = () =>{
    
    const navigate = useNavigate();

    const handleClick = () =>{
        navigate("/");
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
              const response = await fetch('https://localhost:44302/api/rooms');
              console.log(response);
              if (!response.ok) {
                throw new Error('Network response was not ok');
              }
              const result = await response.json();
              console.log(result);
              
            } catch (error) {
                
            } 
          };
      
          fetchData();
      }, []);

    return(
        <div className={style.startWindow}>
            <div className={style.header}>
                <div>
                    <ul>
                        <li key={1}>{userStore.name}</li>
                        
                    </ul>
                    <button onClick={handleClick}>Назад</button>
                </div>
            </div>
            
        </div>
    )
}