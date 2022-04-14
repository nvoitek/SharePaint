import './Legend.scss';

interface LegendProps {
    usersColorsMap: {[user: string] : string};
}

export function Legend(props: LegendProps) {

    return (
        <div className='legend'>
        {
            Object.keys(props.usersColorsMap).map((key: string) => {
                return (
                    <div className='row'>
                        <span className="dot" style={{backgroundColor: props.usersColorsMap[key]}}></span>
                        <p>{key}</p>
                    </div>
                )
            })
        }
        </div>
    );
}