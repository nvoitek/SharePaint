import './Legend.scss';

interface LegendProps {
    usersColorsMap: {[user: string] : string};
}

export function Legend(props: LegendProps) {

    return (
        <>
        {
            Object.keys(props.usersColorsMap).map((key: string) => {
                return (
                    <p>{key} - {props.usersColorsMap[key]}</p>
                );
            })
        }
        </>
    );
}