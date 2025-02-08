import style from "./UserData.module.css";
import { observer } from "mobx-react"
import { TestTab } from "../tabs/testTab";

export const UserData = observer (({activeTab}) =>{
    return(
        <div className={style.data}>
            {
            activeTab == 1 && 
            <div>
                <TestTab></TestTab>
            </div>
            }
            {activeTab == 2 && <div>2 + {activeTab}</div>}
        </div>
    );
});