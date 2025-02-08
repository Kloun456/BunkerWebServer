import React, { useState } from 'react';
import style  from "./testTab.module.css";
import { useNavigate } from 'react-router-dom';
import userStore from "../../../../../stores/UserStore";
import { observer } from "mobx-react"

export const TestTab = observer ((d) => {
    const [password, setPassword] = useState('');
  
    const navigate = useNavigate();

    const handleLogin = () =>{
        navigate("/lobby");
    };

    const onChangeLogin = (event) => {
        userStore.name = event.target.value
    }
  
    const handleRegister = () => {
      console.log('Регистрация:', { username, password });
    };
  
    return (
      <div className={style.logincontainer}>
        <h2>Вход</h2>
        <div className={style.inputGroup}>
          <label>
            Логин:
            <input
              type="text"
              value={userStore.name}
              onChange={(e) => onChangeLogin(e)}
              required
              className={style.inputField}
            />
          </label>
        </div>
        <div className={ style.inputGroup}>
          <label>
            Пароль:
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
              className={style.inputField}
            />
          </label>
        </div>
        <div className={style.buttonGroup}>
          <button onClick={handleLogin} className="button">Войти</button>
          <button onClick={handleRegister} className="button">Зарегистрироваться</button>
        </div>
      </div>
    );
  });
  