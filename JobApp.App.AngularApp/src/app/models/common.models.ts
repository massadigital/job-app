export interface DataResult<T> extends DataQuery {
    Items: T[]
}

export interface DataQuery {
    FilterExpressions: FilterExpression[];
    SortExpressions: SortExpression[];
    Pagination: Pagination;
}

export interface FilterExpression {
    FilterOperator: number;
    Attribute: string;
    Value: string;
}
export interface SortExpression {
    Direction: boolean;
    Expression: string;
}
export interface Pagination {
    PageNumber: number;
    PageSize: number;
    ItemCount: number;
    PageCount: number;
}