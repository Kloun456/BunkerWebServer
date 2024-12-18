import style from "./Tab.module.css"

export const Tab = ({onClick, index, activeTab, caption}) =>{

    return (
        <span 
        onClick={onClick}
        className={index === activeTab ? style.tabActive : style.tabInActive} >
            {caption}
        </span>
    );
}