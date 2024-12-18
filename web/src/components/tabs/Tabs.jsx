import style from "./Tabs.module.css"
import { Tab } from "./Tab";
 
export const Tabs  = ({activeTab, onTabChange, mapTabs}) => {

    const handleClickTab = (index) => {
        onTabChange(index);
    }

    return (
        <div className={style.tabs}>
            { mapTabs.map( mapTab => (
                <Tab
                key={mapTab.id}
                onClick={() => handleClickTab(mapTab.id)}
                caption={mapTab.name}
                activeTab={activeTab}
                index={mapTab.id}/>
            )
            )}
        </div>
    );
}