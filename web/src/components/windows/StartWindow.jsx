import { MainForm } from '../forms/mainForm/MainForm'
import style from './StartWindow.module.css'

export const StartWindow = () =>{
    return(
        <div className={style.startWindow}>
            <div className={style.header}>
                <div className={style.imageContainer}>
                    <img src="/src/assets/cute_girl_logo.jpg" 
                    alt="Не загрузилась девочка"
                    width="100%"
                    height="100%"
                    className={style.image}>
                    </img>
                </div>
            </div>
            <MainForm/>
            <div className={style.footer}>

            </div>
        </div>
    )
}