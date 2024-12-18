import style from "./UserData.module.css";
import { useNavigate } from 'react-router-dom';
import userStore from "../../../../../stores/UserStore";
import { observer } from "mobx-react"


export const UserData = observer (({activeTab}) =>{
    const navigate = useNavigate();

    const handleClick = () =>{
        navigate("/lobby");
    };

    const onChange = (event) => {
        userStore.name = event.target.value
    }

    return(
        <div className={style.data}>
            {
            activeTab == 1 && 
            <div>
                <input 
                onChange={(e) => onChange(e)} 
                value={userStore.name}></input>
                <input
                onChange={(e) => onChange}>
                
                </input>
                <button onClick={handleClick}>Начать</button>
            </div>
            }
            {activeTab == 2 && <div>2 + {activeTab}</div>}
        </div>
    );
});