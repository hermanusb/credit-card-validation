
class CardProviderList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }

    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
            console.log(data);
        };
        xhr.send();
    }

    componentWillMount() {
        this.loadCommentsFromServer();
    }

    render() {
        return (
            <table class="table">
                <tr>
                    <th>Description</th>
                    <th>CreatedDate</th>
                    <th>Lastmodified</th>
                    <th>ValidationRegex</th>
                    <th></th>
                </tr>

                {this.state.data.map((cp) => (
                    <tr>
                        <td>{cp.Description}</td>

                        <td>
                            {ToDateTimeString(parseInt(cp.CreatedDate.replace('/Date(', '').replace(')/', '')))}
                        </td>

                        <td>
                            {ToDateTimeString(parseInt(cp.Lastmodified.replace('/Date(', '').replace(')/', '')))}
                        </td>

                        <td>{cp.ValidationRegex}</td>
                        <td>
                            <a href={'CardProvider/Edit/' + cp.ID}>Edit</a>
                        </td>
                    </tr>
                               
                ))}

              
                {/*        @Html.ActionLink("Edit", "Edit", new {id = item.ID}) |*/}
                {/*        @Html.ActionLink("Details", "Details", new {id = item.ID}) |*/}
                {/*        @Html.ActionLink("Delete", "Delete", new {id = item.ID})*/}
                {/*    </td>*/}
                {/*</tr>*/}

            </table>
        );
    }
}

ReactDOM.render(
    <CardProviderList url="CardProvider/List"/>,
    document.getElementById('content')
);
