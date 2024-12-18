import style from "./MainForm.module.css"
import { User } from "./user/User";
import { Tutorial } from "./tutorial/Tutorial";

export const MainForm = () =>{
    return(
        <div className={style.mainForm}>
            <User/>
            <Tutorial/>
        </div>
    );
}