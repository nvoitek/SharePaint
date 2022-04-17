import './Legend.scss';

interface LegendProps {
    usersColorsMap: {[user: string] : string};
}

export function Legend(props: LegendProps) {

    return (
        <div className='legend'>
        {
            Object.keys(props.usersColorsMap).map((key: string, i: number) => {
                return (
                    <div className='row' key={i}>
                        <span className="dot" style={{backgroundColor: props.usersColorsMap[key]}}></span>
                        <p>{key}</p>
                    </div>
                )
            })
        }
        </div>
    );
}