import { useState } from "react";
import style from "./User.module.css"
import { UserData } from "./data/UserData";
import { Tabs } from "../../../tabs/Tabs";

export const User = () =>{
    const [activeTab, setActiveTab] = useState(1);

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

    const tabs = [
        { id: 1, name: "С аунтентификацией"},
        { id: 2, name: "Анономно"}
    ];

    return(
        <div className={style.user}>
            <Tabs 
            activeTab={activeTab} 
            onTabChange={handleTabChange}
            mapTabs={tabs}/>
           
            <UserData activeTab={activeTab}/> 
        </div>
    );
}